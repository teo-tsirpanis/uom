using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Dai19090.Pdp
{
    static class Program
    {
        private const int ArraySize = 1_000_000;
        private static readonly int P = Environment.ProcessorCount;
        private static readonly int[] TheArray = GenerateRandomArray();

        static int[] GenerateRandomArray()
        {
            var rng = new Random();
            var xs = new int[ArraySize];
            for (int i = 0; i < xs.Length; i++)
            {
                // Υπάρχει κίνδυνος overflow με μεγάλους αριθμούς.
                xs[i] = rng.Next(-1000, 1000);
            }

            return xs;
        }

        // Η κατάτμηση του πίνακα δεν είναι αρμοδιότητα του νήματος.
        // Ο τύπος ReadOnlyMemory είναι ένα τμήμα ενός πίνακα που ξεκινάει κανονικά από το 0.
        static ReadOnlyMemory<int> GetArraySegment(int[] xs, int threadId)
        {
            var start = threadId * (ArraySize / P);
            if (threadId == P - 1)
                // The last thread gets the rest of the array.
                return xs.AsMemory().Slice(start);
            return new ReadOnlyMemory<int>(xs, start, ArraySize / P);
        }

        static void RunItAndTimeIt(string name, Func<(int, int)> f)
        {
            Console.WriteLine($"Running {name}...");
            var sw = new Stopwatch();
            sw.Start();
            var (pos, neg) = f();
            sw.Stop();
            Console.WriteLine($"Finished in {sw.Elapsed}");
            Console.WriteLine($"Sum of positives: {pos}");
            Console.WriteLine($"Sum of negatives: {neg}");
            Console.WriteLine();
        }

        static void SumLocalThreadResult(ReadOnlyMemory<int> xs, out int positiveLocal, out int negativeLocal)
        {
            positiveLocal = 0;
            negativeLocal = 0;
            var span = xs.Span;
            foreach (var x in span)
            {
                if (x > 0)
                    positiveLocal += x;
                else
                    negativeLocal += x;
            }
        }

        static void SumGlobalThreadResultInefficient(ReadOnlyMemory<int> xs, ref int positiveGlobal,
            ref int negativeGlobal, object positiveLock, object negativeLock)
        {
            var span = xs.Span;
            foreach (var x in span)
            {
                // Στην C# το κάθε αντικείμενο έχει το δικό του κλείδωμα και επόπτη.
                // Το lock που θα δούμε παρακάτω είναι συντομογραφία των συναρτήσεων Monitor.Enter/Exit.
                if (x > 0)
                    lock (positiveLock)
                        positiveGlobal += x;
                else
                    lock (negativeLock)
                        negativeGlobal += x;
            }
        }

        static void SumGlobalThreadResultDoneRight(ReadOnlyMemory<int> xs, ref int positiveGlobal,
            ref int negativeGlobal, object positiveLock, object negativeLock)
        {
            int positiveLocal = 0;
            int negativeLocal = 0;
            var span = xs.Span;
            foreach (var x in span)
            {
                if (x > 0)
                    positiveLocal += x;
                else
                    negativeLocal += x;
            }

            // Θα μπορούσαμε να χρησιμοποιήσουμε την κλάση Interlocked
            // (αντίστοιχη των Atomic*** της Java) για ακόμα μεγαλύτερη απόδοση.
            lock (positiveLock) positiveGlobal += positiveLocal;
            lock (negativeLock) negativeGlobal += negativeLocal;
        }

        // Και μια σειριακή εκτέλεση για σύγκριση χρόνου και έλεγχο ορθότητας.
        static (int, int) Experiment0()
        {
            int pos = 0, neg = 0;
            for (var i = 0; i < TheArray.Length; i++)
            {
                var x = TheArray[i];
                if (x > 0)
                    pos += x;
                else
                    neg += x;
            }

            return (pos, neg);
        }

        // Κάθε συνάρτηση "πειράματος" επιστρέφει το άθροισμα των θετικών και των αρνητικών μεταβλητών.
        static (int, int) Experiment1()
        {
            Thread[] threads = new Thread[P];
            int[] pos = new int[P];
            int[] neg = new int[P];
            for (int i = 0; i < threads.Length; i++)
            {
                // Βάζουμε τοπική μεταβλητή επειδή το i θα έχει αλλάξει μέχρι να έρθει η ώρα να εκτελεστούν τα νήματα.
                var id = i;
                var segment = GetArraySegment(TheArray, id);
                threads[i] = new Thread(() => SumLocalThreadResult(segment, out pos[id], out neg[id]));
                threads[i].Start();
            }

            foreach (var thread in threads) thread.Join();

            return (pos.Sum(), neg.Sum());
        }

        static (int, int) Experiment2()
        {
            Thread[] threads = new Thread[P];
            int pos = 0;
            int neg = 0;
            object positiveLock = new object();
            object negativeLock = new object();
            for (int i = 0; i < threads.Length; i++)
            {
                var id = i;
                var segment = GetArraySegment(TheArray, id);
                threads[i] = new Thread(() =>
                    SumGlobalThreadResultInefficient(segment, ref pos, ref neg, positiveLock, negativeLock));
                threads[i].Start();
            }

            foreach (var thread in threads) thread.Join();

            return (pos, neg);
        }

        static (int, int) Experiment3()
        {
            Thread[] threads = new Thread[P];
            int pos = 0;
            int neg = 0;
            object positiveLock = new object();
            object negativeLock = new object();
            for (int i = 0; i < threads.Length; i++)
            {
                var id = i;
                var segment = GetArraySegment(TheArray, id);
                threads[i] = new Thread(() =>
                    SumGlobalThreadResultDoneRight(segment, ref pos, ref neg, positiveLock, negativeLock));
                threads[i].Start();
            }

            foreach (var thread in threads) thread.Join();

            return (pos, neg);
        }

        static void Main()
        {
            Console.WriteLine($"We have {P} cores.");

            RunItAndTimeIt("Sequential", Experiment0);
            RunItAndTimeIt("Parallel with local sums and centralized aggregation", Experiment1);
            RunItAndTimeIt("Parallel with global sum and bad mutex", Experiment2);
            RunItAndTimeIt("Parallel with global sum and good mutex", Experiment3);
        }
    }
}
