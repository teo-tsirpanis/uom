# Διανυσματοποιημένος κώδικας στο .NET

### Τσιρπάνης Θεόδωρος `dai19090`

Ένας από τους λόγους που το .NET επιτρέπει τη συγγραφή κώδικα υψηλών επιδόσεων είναι η υποστήριξη του προγραμματιστικού μοντέλου SIMD (Single Instruction Multiple Data), ο λεγόμενος _διανυσματοποιημένος κώδικας_. Υπάρχουν τρεις τρόποι για να το πετύχουμε αυτό.

> Το JIT του .NET δεν πραγματοποιεί προς το παρόν αυτόματη διανυσματοποίηση.

## Διανύσματα μεταβλητού μήκους

Ο τύπος `System.Numerics.Vector<T>` [εισήχθη το 2015 με το .NET Framework 4.6](https://devblogs.microsoft.com/dotnet/the-jit-finally-proposed-jit-and-simd-are-getting-married/) και αναπαριστά ένα διάνυσμα τιμών συγκεκριμένου τύπου. Το μήκος του διανύσματος εξαρτάται από τον τύπο των τιμών και την υποστήριξη του υλικού. Για παράδειγμα αν ο επεξεργαστής μας υποστηρίζει SIMD 128 μπιτ, ο τύπος `Vector<int>` θα κρατάει τέσσερις ακεραίους των 32 μπιτ, και αν υποστηρίζει SIMD 256 μπιτ, θα κρατάει οκτώ. Ακολουθεί ένα απλό παράδειγμα όπου υπολογίζουμε το άθροισμα των στοιχείων ενός πίνακα:

```csharp
using System.Numerics;

static double SumVector(double[] x)
{
    double sum = 0;
    int i = 0;

    if (Vector.IsHardwareAccelerated)
    {
        Vector<double> sumVec = Vector<double>.Zero;
        // Δεν ξέρουμε πόσους αριθμούς χωράει ένα vector, γι' αυτό χρησιμοποιούμε το Count.
        for (; i < x.Length - Vector<double>.Count; i += Vector<double>.Count)
        {
            // Δημιουργούμε ένα vector που ξεκινάει από το i-οστό στοιχείο του πίνακα x.
            sumVec += new Vector<double>(x, i);
        }
        sum = Vector.Sum(sumVec);
    }

    // Προσθέτουμε τα νούμερα που περίσσεψαν.
    for (; i < x.Length; i++)
    {
        sum += x[i];
    }

    return sum;
}
```

[Βλέποντας τον παραγόμενο κώδικα](https://sharplab.io/#v2:EYLgxg9gTgpgtADwGwBYA0AXEBDAzgWwB8ABABgAJiBGAOgDkBXfGKASzFwG4BYAKD+IBmSgCZyAYXIBvPuTmVh1JOQAmEBsAA2McgGUmusNk3YoACjUbtAbQC65BAEpZ8mb3kfV6rTtxNyALzkpDzunnIu4QBm0ORmrAB2GOSsgcGcKeQAPA40ADIwCQDmGAAWGawA1JXOYeFu4eF++OSVQQjWrLahjeQAvpGegx7EAOzkzT3yA/x1CpRUypY+ekwAajBgGNAW3jb2ToMNjcvaE/5BIcPyicmpl1Ph13KsUXEbW9A0AJK4ABKmFQAd1MMAAgmAwDBtFBsBgYCpar1jr05B9tlAsqcYAA+c74D5pdHQLF7XE0ABaLAgj1RAHo6eRACnAgFbgQC9wORAH3AgFrgQCDwIB+4EAo8CAHuAWeRAAPAgBngQDDwELAEPA5EAjcC8wCdwIAO4GF/MAs8AKwDjwIBJ4F5gBrgFkq8jctmK8gAN02GLQ5EAzcAqgDkSsFgBHgSXkXW8wDtwNKVZrxfyVdrReQPfyJOokjRnp4YlA4hVsrkCsUyuQ4ORiZjsTiaOJYxhU21c3aSQWiyWkai5Cj6/IGcy/cKw4LeY7w2KLVbbZ9kyHBVyWYAu4BVbJNZsVUsj0dYcH50q95BXod1LMA9cDRqMj8Vby1jq0IeNzJv4wnlhIwIEVwekqy4swIB2sRy03ozC/NImVqA0Po+BmM0Hwfgm36NAmLaAAXAArSmq3J7hGHpWmyPa8law4SiyvJbtK0osoAE8CKmyZ69EmKaZDkp4ZiU5QpNUdb1AmHi/uWHRdJ+0wJgmYz4rSMwzEAA==), η διανυσματοποιημένη επανάληψη χρησιμοποιεί το σύνολο εντολών AVX και προσθέτει τέσσερις πραγματικούς αριθμούς διπλής ακρίβειας σε κάθε βήμα:

```
L0024: vmovupd ymm0, [rcx+rax*8+0x10]
L002b: vaddpd ymm1, ymm1, ymm0
L0030: add eax, 4
L0033: cmp r8d, eax
L0036: jg short L0024
```

> Το namespace `System.Numerics` περιέχει και κάποιους άλλους τύπους διανυσμάτων που ενδέχεται να υλοποιούνται με διανυσματοποιημένο τρόπο (`Matrix3x2`, `Matrix4x4`, `Plane`, `Quaternion`, `Vector2`, `Vector3` και `Vector4`) αλλά έχουν σταθερό μέγεθος και υποστηρίζουν μόνο πραγματικούς αριθμούς μονής ακρίβειας.

**Πλεονεκτήματα**

* Υπάρχει τον περισσότερο καιρό από τα άλλα SIMD APIs, που σημαίνει ότι είναι διαθέσιμο σε περισσότερες εκδοχές του .NET.
* Η πιο εύκολη στην χρήση επιλογή.
* Γράφοντας τον κώδικα μια φορά μπορούμε να υποστηρίξουμε τους μεγαλύτερους καταχωρητές SIMD που είναι διαθέσιμοι στο υλικό που τρέχει ο κώδικας. Όταν το .NET υποστηρίξει SIMD 512 μπιτ ο κώδικάς μας είναι ήδη συμβατός.

**Μειονεκτήματα**

* Η μεταβλητότητα του μεγέθους του `Vector<T>` είναι δίκοπο μαχαίρι και έχει κάποια αρνητικά:
    * Ορισμένες πράξεις που προϋποθέτουν σταθερό μήκος (όπως shuffle και move-mask) δεν είναι διαθέσιμες.
    * Κώδικας που τον χρησιμοποιεί δεν υποστηρίζεται από το [ReadyToRun](https://docs.microsoft.com/en-us/dotnet/core/deploying/ready-to-run), μια τεχνολογία που προμεταγλωττίζει τον κώδικα της εφαρμογής για να μειώσει τον χρόνο εκτέλεσης του JIT κατά την εκκίνηση.
    * Δεν είναι πάντα επιθυμητό να χρησιμοποιήσουμε τους μεγαλύτερους καταχωρητές, για παράδειγμα αν τα δεδομένα μας είναι μικρού μεγέθους.

## Hardware intrinsics

Ακολουθώντας τους μεταγλωττιστές των native γλωσσών, το .NET προσφέρει από το 2019 τα λεγόμενα [hardware intrinsics](https://devblogs.microsoft.com/dotnet/hardware-intrinsics-in-net-core/), τα οποία είναι συναρτήσεις που κατά τη μεταγλώττιση από το JIT μεταφράζονται σε συγκεκριμένες εντολές του επεξεργαστή. Πρώτα προστέθηκε υποστήριξη για intrinsics [της αρχιτεκτονικής x86](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.intrinsics.x86), μετά στο .NET 5 [της αρχιτεκτονικής ARM](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.intrinsics.arm), και στο .NET 8 σχεδιάζονται να προστεθούν intrinsics [των εντολών SIMD της WebAssembly](https://github.com/dotnet/runtime/issues/53730). Για τον σκοπό αυτόν προστέθηκαν οι τύποι διανυσμάτων σταθερού μήκους `Vector64<T>`, `Vector128<T>` και `Vector256<T>`.

> Τα hardware intrinsics δεν είναι μόνο για SIMD, μας δίνουν πρόσβαση και σε άλλες εντολές του επεξεργαστή όπως την [`CPUID`](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.intrinsics.x86.x86base.cpuid?view=net-6.0) που μας δίνει ένα σωρό πληροφορίες για τον επεξεργαστή που μπορεί να είναι χρήσιμες για κάποιους αλγορίθμους (όπως μέγεθος cache).

Ακολουθεί η προηγούμενη συνάρτηση γραμμένη με intrinsics του συνόλου εντολών AVX:

```csharp
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

// Χρειαζόμαστε τη λέξη unsafe επειδή χρησιμοποιούμε δείκτες.
public static unsafe double SumIntrinsics(double[] x)
{
    double sum = 0;
    int i = 0;
    int length = x.Length;

    // Με τη λέξη fixed λέμε στον Garbage Collector να μη μετακινήσει
    // τον πίνακα, όσο χρησιμοποιούμε τη διεύθυνση των στοιχείων του.
    fixed (double* ptr = &x[0])
    {
        if (Avx.IsSupported && length >= Vector256<double>.Count)
        {
            Vector256<double> sumVec = Vector256<double>.Zero;
            for (; i < length - Vector256<double>.Count; i += Vector256<double>.Count)
            {
                sumVec = Avx.Add(sumVec, Avx.LoadVector256(ptr + i));
            }
            // Έστω ότι το διάνυσμα με το άθροισμα είναι S1|S2|S3|S4
            // Η HorizontalAdd ισοδυναμεί με την εντολή VHADDPD
            // και μας δίνει S1+S2|S1+S2|S3+S4|S3+S4.
            sumVec = Avx.HorizontalAdd(sumVec, sumVec);
            // Σπάμε το μεγάλο διάνυσμα στα πάνω και κάτω κομμάτια των 128 μπιτ
            // S1+S2|S1+S2 και S3+S4|S3+S4, τα προσθέτουμε, και το κάτω τμήμα
            // του διανύσματος το αναθέτουμε στο sum.
            Vector128<double> sum128 = Sse2.Add(sumVec.GetLower(), sumVec.GetUpper());
            sum = sum128.ToScalar();
        }

        for (; i < length; i++)
        {
            sum += ptr[i];
        }
    }

    return sum;
}
```

__Πλεονεκτήματα__

* Μας δίνουν σχεδόν απεριόριστη πρόσβαση στον επεξεργαστή και μπορούμε να εκμεταλλευτούμε τις δυνατότητές του στο έπακρο και με τρόπους που το JIT δε θα έκανε από μόνο του, χωρίς να γράψουμε native κώδικα.

__Μειονεκτήματα__

* Καθόλου φορητά: Αν θέλουμε να υποστηρίξουμε SIMD κάποιου άλλου μεγέθους ή κάποιας άλλης αρχιτεκτονικής, πρέπει να ξαναγράψουμε τον αλγόριθμο πολλές φορές.
* Πιο δύσκολα στη χρήση: από αφηρημένες πράξεις σε διανύσματα, τώρα έχουμε συγκεκριμένες εντολές της γλώσσας μηχανής. Απαιτείται να έχουμε οικειότητα με την εκάστοτε αρχιτεκτονική.

## Διανύσματα σταθερού μήκους

Όταν εισήχθησαν, οι τύποι των διανυσμάτων σταθερού μήκους είχαν λίγα μέλη από μόνοι τους, τα οποία έχουν να κάνουν με τη δημιουργία τους, την απόσπαση στοιχείων και την αλλαγή τύπου. Για οποιασδήποτε μορφής πράξεις έπρεπε να καταφύγουμε σε hardware intrinsics.

[Αυτό άλλαξε με το .NET 7.](https://github.com/dotnet/runtime/issues/49397) Μπορούμε πια να κάνουμε πράξεις στους τύπους `Vector64<T>`, `Vector128<T>` και `Vector256<T>` χωρίς να χρησιμοποιήσουμε hardware intrinsics. Ακολουθεί το παραπάνω πρόγραμμα γραμμένο με διανύσματα σταθερού μήκους, υποστηρίζοντας SIMD και 256 και 128 μπιτ:

```csharp
using System.Runtime.Intrinsics;

static unsafe double SumFixedVectors(double[] x)
{
    double sum = 0;
    int i = 0;
    int length = x.Length;

    fixed (double* ptr = &x[0])
    {
        if (Vector256.IsHardwareAccelerated)
        {
            Vector256<double> sumVec = Vector256<double>.Zero;
            for (; i < length - Vector256<double>.Count; i += Vector256<double>.Count)
            {
                sumVec += Vector256.Load(ptr + i);
            }
            sum = Vector256.Sum(sumVec);
        }

        if (Vector128.IsHardwareAccelerated)
        {
            Vector128<double> sumVec = Vector128<double>.Zero;
            for (; i < length - Vector128<double>.Count; i += Vector128<double>.Count)
            {
                sumVec += Vector128.Load(ptr + i);
            }
            sum += Vector128.Sum(sumVec);
        }

        for (; i < length; i++)
        {
            sum += ptr[i];
        }
    }

    return sum;
}
```

__Πλεονεκτήματα__

* Πιο εύκολα στη χρήση και πιο φορητά από τα hardware intrinsics.
* Πιο ευέλικτα από τα διανύσματα μεταβλητού μήκους· επειδή το μέγεθός τους είναι σταθερό μπορούμε να πραγματοποιήσουμε πράξεις όπως [shuffle](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.intrinsics.vector128.shuffle) και [move-mask](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.intrinsics.vector128.extractmostsignificantbits).

__Μειονεκτήματα__

* Πάλι χρειάζεται να γράψουμε τον ίδιο κώδικα πολλές φορές για τα διάφορα μήκη διανυσμάτων. Και δεν είναι προφανές ποια από αυτά χρειάζεται να υποστηρίξει ο κώδικάς μας. Το πιο ευρέως υποστηριζόμενο είναι το `Vector128<T>`, το `Vector256<T>` υποστηρίζεται σε επεξεργαστές της αρχιτεκτονικής x86 με AVX, και το `Vector64<T>` δε χρειάζεται να μας απασχολεί (προστέθηκε για κάποια intrinsics της αρχιτεκτονικής ARM).
    * Το πρόβλημα αυτό θα γίνει πιο περίπλοκο [μόλις προστεθεί και ο τύπος `Vector512<T>`](https://github.com/dotnet/runtime/issues/73262).

## Εφαρμογές διανυσματοποιημένου κώδικα στο .NET

Η κλάση `System.MemoryExtensions` περιέχει συναρτήσεις για ορισμένες συνήθεις λειτουργίες σε περιοχές μνήμης, οι οποίες όπως αναφέραμε πριν δύνανται να διανυσματοποιηθούν. Από τις συναρτήσεις αυτές μας ενδιαφέρουν για τις κανονικές εκφράσεις δύο:

* Η συνάρτηση `IndexOf` είναι το αντίστοιχο της συνάρτησης `strstr` της C. Δέχεται ως παραμέτρους δύο περιοχές μνήμης και επιστρέφει τη θέση της πρώτης εμφάνισης των περιεχομένων της δεύτερης περιοχής στην πρώτη, ή $-1$ αν δεν υπάρχει. Αν οι περιοχές μνήμης περιέχουν χαρακτήρες, η συνάρτηση χρησιμοποιεί [μια διανυσματοποιημένη υλοποίηση](https://github.com/dotnet/runtime/blob/7fac450bbbaf05d694c4ee878815f864a47c4952/src/libraries/System.Private.CoreLib/src/System/SpanHelpers.Char.cs#L14-L205).
* Η συνάρτηση `IndexOfAny` είναι το αντίστοιχο της συνάρτησης `strpbrk` της C. δέχεται ως παραμέτρους δύο περιοχές μνήμης και επιστρέφει τη θέση της πρώτης εμφάνισης ενός εκ των στοιχείων της δεύτερης περιοχής στην πρώτη, ή $-1$ αν δεν υπάρχει. Αν οι περιοχές μνήμης περιέχουν χαρακτήρες και οι χαρακτήρες που ψάχνουμε είναι το πολύ 5, η συνάρτηση χρησιμοποιεί μια διανυσματοποιημένη υλοποίηση.

> Οι περιοχές μνήμης αναπαρίστανται με τους τύπους `Span<T>` και `ReadOnlySpan<T>`, και είναι στην ουσία ένας συνδυασμός δείκτη και μήκους. Μπορούν να αναπαριστούν μνήμη από πίνακες, τμήματα πινάκων, strings, τμήματα strings, μνήμη από τη στοίβα, ή μνήμη από κάποιον δυναμικό εκχωρητή μνήμης όπως τη συνάρτηση `malloc`. Αποτελούν το Α και το Ω σε κάθε κώδικα υψηλών επιδόσεων στο .NET. Περισσότερες πληροφορίες για τους τύπους αυτούς είναι διαθέσιμες στο https://docs.microsoft.com/en-us/archive/msdn-magazine/2018/january/csharp-all-about-span-exploring-a-new-net-mainstay και https://adamsitnik.com/Span/.


<script type="text/javascript" src="http://cdn.mathjax.org/mathjax/latest/MathJax.js?config=TeX-AMS-MML_HTMLorMML"></script>
<script type="text/x-mathjax-config">
    MathJax.Hub.Config({ tex2jax: {inlineMath: [['$', '$']]}, messageStyle: "none" });
</script>
