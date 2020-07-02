using System.Collections.Generic;
using System.Threading;

namespace Dai19090.Pdp
{
    // Επειδή ορισμένος κώδικας επαναχρησιμοποιείται, θα χρησιμοποιήσουμε κληρονομικότητα.
    public abstract class AbstractBuffer
    {
        // Δε θα ασχοληθούμε με τα μαθηματικά της αποθήκευσης σε πίνακα, θα
        // έχουμε μια απεριόριστη ουρά που θα ελέγχουμε χειροκίνητα αν γέμισε.
        // Το ζητούμενο της άσκησης άλλωστε είναι οι μηχανισμοί ταυτοχρονισμού.
        protected const int MaxCount = 1000;

        // Το readonly σμηαίνει ότι το αντικείμενο δεν αλλάζει, όχι το περιεχόμενό του.
        protected readonly Queue<int> q = new Queue<int>();
        protected bool IsEmpty => q.Count == 0;
        protected bool IsFull => q.Count == MaxCount;

        public abstract void Put(int data);
        public abstract int Get();
    }

    public class LockCondBuffer : AbstractBuffer
    {
        // Όπως είπαμε στο προηγούμενο θέμα, ένα αντικείμενο
        // έχει ενσωματομένα ένα κλείδωμα και έναν επόπτη.
        private readonly object _lock = new object();
        private readonly object emptyCond = new object();
        private readonly object fullCond = new object();

        public override void Put(int data)
        {
            lock (_lock)
            {
                // Αντίστοιχο με το fullCond.await() της Java,
                // αλλά απλούστερο και χωρίς τα ενοχλητικά try/catch
                while (IsFull) Monitor.Wait(fullCond);

                q.Enqueue(data);

                // Αντίστοιχο με το emptyCond.notifyAll() της Java.
                // Το notify λέγεται Monitor.Pulse().
                Monitor.PulseAll(emptyCond);
            }
        }

        public override int Get()
        {
            lock (_lock)
            {
                while (IsEmpty) Monitor.Wait(emptyCond);

                var x = q.Dequeue();

                Monitor.PulseAll(fullCond);

                return x;
            }
        }
    }

    public class SemaphoreBuffer : AbstractBuffer
    {
        // Η κλάση SemaphoreSlim είναι ο, τι ακριβώς
        // λέει το όνομά της: ένας σηματοφόρος.
        private readonly SemaphoreSlim mutex = new SemaphoreSlim(1);
        private readonly SemaphoreSlim semFull = new SemaphoreSlim(0);
        private readonly SemaphoreSlim semEmpty = new SemaphoreSlim(MaxCount);

        public override void Put(int data)
        {
            // Ισοδύναμο με το Up(semEmpty).
            semEmpty.Wait();
            mutex.Wait();

            q.Enqueue(data);

            // Ισοδύναμο με το Down(mutex).
            mutex.Release();
            semFull.Release();
        }

        public override int Get()
        {
            semFull.Wait();
            mutex.Wait();

            var x = q.Dequeue();

            mutex.Release();
            semEmpty.Release();

            return x;
        }
    }
}
