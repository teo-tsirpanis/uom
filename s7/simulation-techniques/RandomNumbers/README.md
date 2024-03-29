# Τεχνικές προσομοίωσης ~ Άσκηση 1

### Θοδωρής Τσιρπάνης (`dai19090`)

## Η υλοποίηση

Το πρόγραμμα της εργασίας είναι γραμμένο στην γλώσσα προγραμματισμού C# 9.0 και εκτελείται στο περιβάλλον .NET. Ακολουθεί μια αντικειμενοστρεφή αρχιτεκτονική, διαχωρίζοντας σε επίπεδο οργάνωσης κώδικα την γεννήτρια τυχαίων αριθμών από τα στατιστικά της τεστ, και διατηρώντας το σημείο εισόδου του μικρό σε μέγεθος.

Οι δύο κύριες διεπαφές του προγράμματος είναι οι `IRandomNumberGenerator` και `IRandomNumberAnalyzer`. Η πρώτη έχει μια μέθοδο με όνομα `NextDouble` που δεν δέχεται παραμέτρους και επιστρέφει έναν πραγματικό αριθμό διπλής ακρίβειας μεταξύ 0 και 1.

Η δεύτερη διεπαφή έχει δύο μεθόδους, την `RecordMeasurement` που δέχεται έναν πραγματικό αριθμό διπλής ακρίβειας και τον λαμβάνει υπ' όψιν στην στατιστική μέτρηση, και την `WriteResultsTo` που γράφει τα αποτελέσματα της στατιστικής μέτρησης σε ένα αντικείμενο τύπου `System.IO.TextWriter`, προσφέροντας μια αφαίρεση στον προορισμό των αποτελεσμάτων (το πρόγραμμα τα γράφει στην κονσόλα αλλά θα μπορούσε με λίγες αλλαγές να τα γράφει σε ένα αρχείο, στη μνήμη ή οπουδήποτε αλλού).

Η μόνη υλοποίηση της διεπαφής `IRandomNumberGenerator` είναι η κλάση `DefaultLinearCongruentialGenerator` που υλοποιεί την γραμμική ισοϋπόλοιπη γεννήτρια της εκφώνησης. Δέχεται την αρχική τιμή ως παράμετρο στον δημιουργό (constructor).

Υπάρχουν τέσσερις υλοποιήσεις της διεπαφής `IRandomNumberAnalyzer`:

* `MeasuresOfPositionAnalyzer`: υπολογίζει τον μέσο όρο και την τυπική απόκλιση των αριθμών, και τα εμφανίζει, καθώς και την διαφορά τους από τις αναμενόμενες τιμές. Χρησιμοποιούνται αλγόριθμοι που δεν προϋποθέτουν την διατήρηση όλων των αριθμών στη μνήμη.
    * `LimitedMeasuresOfPositionAnalyzer`: όπως η κλάση `MeasuresOfPositionAnalyzer`, αλλά λαμβάνει υπ' όψιν μόνο τους πρώτους N αριθμούς που δέχεται. Μαζί με τα στατιστικά θέσης, εμφανίζει και τους αριθμούς αυτούς. Είναι υποκλάση της παραπάνω κλάσης, για ελαχιστοποίηση του διπλότυπου κώδικα. Το N είναι παραμετροποιήσιμο αλλά στην εκτέλεση του προγράμματος είναι πάντα ίσο με το 100.
* `RunsTestAnalyzer`: πραγματοποιεί ένα runs test στους αριθμούς, μετρώντας τις ακολουθίες όπου N συνεχόμενοι αριθμοί είναι μεγαλύτεροι ή μικρότεροι του 0.5. Στο τέλος εμφανίζει τις συχνότητες αυτές, τα ποσοστά εμφάνισης για κάθε μήκος της ακολουθίας, και την διαφορά τους. Το N είναι παραμετροποιήσιμο αλλά στην εκτέλεση του προγράμματος είναι πάντα ίσο με το 10.
* `RegionsTestAnalyzer`: πραγματοποιεί ένα τεστ περιοχών στους αριθμούς, μετρώντας την συχνότητά τους μέσα σε δέκα ισομεγέθεις περιοχές.

Το πρόγραμμα όταν εκτελείται πραγματοποιεί σε γενικές γραμμές τα εξής βήματα:

1. Δημιουργεί ένα αντικείμενο τύπου `DefaultLinearCongruentialGenerator` και του δίνει μια τυχαία αρχική τιμή από την προϋπάρχουσα γεννήτρια τυχαίων αριθμών του .NET.
2. Δημιουργεί έναν πίνακα αντικειμένων που υλοποιούν την διεπαφή `IRandomNumberAnalyzer`, δίνοντάς τους τις κατάλληλες παραμέτρους.
3. Ξεκινάει ένα χρονόμετρο.
4. Για ένα εκατομμύριο φορές καλεί την μέθοδο `NextDouble` της γεννήτριας του βήματος 1 και δίνει την τιμή που επέστρεψε στην μέθοδο `RecordMeasurement` του κάθε αντικειμένου του βήματος 2.
5. Σταματάει το χρονόμετρο του βήματος 3 και εμφανίζει τον χρόνο που πέρασε.
6. Για κάθε αντικείμενο του βήματος 2 καλεί την μέθοδο `WriteResultsTo` με παράμετρο το αντικείμενο `Console.Out` που συμβολίζει την τυπική έξοδο (stdout), στην οποία θα γραφτούν τα αποτελέσματα.

Οι διαφορές από τις αναμενόμενες τιμές εμφανίζονται σε επιστημονική μορφή, καταδεικνύοντας ευκολότερα την τάξη μεγέθους τους.

## Παράδειγμα εκτέλεσης

```
Using seed 1142850159
Testing the RNG with 1000000 samples
Finished in 00:00:00.0759638
Displaying results

--------------------FIRST 100 NUMBERS--------------------
0.7311262 0.5553088 0.8169828 0.4978893 0.5814785 0.9258942 0.3558021 0.0272923 0.6245668 0.3610543
0.2864271 0.7506576 0.0558996 0.1470434 0.5510666 0.9558989 0.6333251 0.6659337 0.8212004 0.5034934
0.4654835 0.1493987 0.2225545 0.1613199 0.5717435 0.5242950 0.0659368 0.5781703 0.0573731 0.3187899
0.1776808 0.6146818 0.2476950 0.0977861 0.9234495 0.2504414 0.6249759 0.3963936 0.5191485 0.7860124
0.9118012 0.6201982 0.7226987 0.5586328 0.1446826 0.8810769 0.5004176 0.8903350 0.0816517 0.2373101
0.7617611 0.4872380 0.7875863 0.3067410 0.7561736 0.0087613 0.7410227 0.7217314 0.2257983 0.0255108
0.3062009 0.3946650 0.9077964 0.0845859 0.9140954 0.0627467 0.4800257 0.1010597 0.7961798 0.0808498
0.5438288 0.7943797 0.6146754 0.9311591 0.7376808 0.3884415 0.8330350 0.4183616 0.5754457 0.2940837
0.1704107 0.0191338 0.1029929 0.9927550 0.9838556 0.3546759 0.9669225 0.8401028 0.9220110 0.2550424
0.9891507 0.0082345 0.6940266 0.3840209 0.8411037 0.2853994 0.2974664 0.8933061 0.9112719 0.9518440

Mean: 0.510958 (should be near 0.5, difference is 1.095824E-002)
Standard deviation: 0.302871 (should be near 0.288675, difference is 1.419633E-002)

--------------------MEASURES OF POSITION--------------------
Mean: 0.500174 (should be near 0.5, difference is 1.739783E-004)
Standard deviation: 0.288616 (should be near 0.288675, difference is 5.935508E-005)

--------------------RUNS TEST--------------------
This test measures the "runs" of numbers above/below 0.5.
For each run both should occur about the same number of times.
1-runs: 125106/125203 (49.98 %/50.02 %, difference is 3.875210E-004)
2-runs: 62273/61947 (50.13 %/49.87 %, difference is 2.624376E-003)
3-runs: 31212/31681 (49.63 %/50.37 %, difference is 7.457110E-003)
4-runs: 15679/15645 (50.05 %/49.95 %, difference is 1.085430E-003)
5-runs: 7899/7749 (50.48 %/49.52 %, difference is 9.585890E-003)
6-runs: 3905/3938 (49.79 %/50.21 %, difference is 4.207574E-003)
7-runs: 2032/1980 (50.65 %/49.35 %, difference is 1.296112E-002)
8-runs: 980/996 (49.60 %/50.40 %, difference is 8.097166E-003)
9-runs: 493/471 (51.14 %/48.86 %, difference is 2.282158E-002)
10-runs: 491/450 (52.18 %/47.82 %, difference is 4.357067E-002)

--------------------REGIONS TEST--------------------
This test measures the numbers' frequency within even-spaced regions.
Each region's frequency should be around 100000 (10.00 %).
[0, 0.1): 99798 (9.98 %, difference is 2.020000E+002)
[0.1, 0.2): 99852 (9.99 %, difference is 1.480000E+002)
[0.2, 0.3): 100096 (10.01 %, difference is 9.600000E+001)
[0.3, 0.4): 100078 (10.01 %, difference is 7.800000E+001)
[0.4, 0.5): 99835 (9.98 %, difference is 1.650000E+002)
[0.5, 0.6): 100183 (10.02 %, difference is 1.830000E+002)
[0.6, 0.7): 99712 (9.97 %, difference is 2.880000E+002)
[0.7, 0.8): 100251 (10.03 %, difference is 2.510000E+002)
[0.8, 0.9): 100437 (10.04 %, difference is 4.370000E+002)
[0.9, 1): 99758 (9.98 %, difference is 2.420000E+002)
```

## Συμπεράσματα

Τα αποτελέσματα φαίνονται ικανοποιητικά, υποδεικνύοντας ότι η γεννήτρια ακολουθεί ομοιόμορφη κατανομή.

## Παρατηρήσεις

* Δεν φαίνεται στα τεστ αλλά οι πραγματικοί αριθμοί διπλής ακρίβειας που παράγει η γεννήτρια δεν έχουν αρκετή εντροπία. Ένας πραγματικός αριθμός διπλής ακρίβειας χρησιμοποιεί πενήντα οκτώ μπιτ για να αποθηκεύσει το κλασματικό του μέρος, ενώ η γεννήτρια αυτή παράγει αριθμούς εντροπίας τριάντα ενός μπιτ. Πραγματικοί αριθμοί πλήρους εντροπίας θα μπορούσαν να παραχθούν παίρνοντας τα πρώτα είκοσι τέσσερα μπιτ του ακεραίου και διαιρώντας τα με το 2<sup>24</sup>, το πλήθος μπιτ του κλασματικού μέρους ενός πραγματικού αριθμού _απλής_ ακρίβειας, [όπως κάνει το .NET](https://github.com/dotnet/runtime/blob/d40f560efbf4f85ec6d59892a6c4bafa39f66d19/src/libraries/System.Private.CoreLib/src/System/Random.Xoshiro256StarStarImpl.cs#L256), αλλά δεν υλοποιήθηκε επειδή η εκφώνηση μιλάει συγκεκριμένα για διαίρεση με το 2<sup>32</sup>. Για τον λόγο αυτόν εμφανίζονται μόνο τα πρώτα εφτά δεκαδικά ψηφία των πρώτων εκατό αριθμών της γεννήτριας.

* Η κλάση `LimitedMeasuresOfPositionAnalyzer`, κατά παρέκκλιση από την εκφώνηση αποθηκεύει τους εκατό πρώτους τυχαίους αριθμούς _μόνο για την εμφάνισή τους_ στο τέλος της εκτέλεσης. Τονίζω το "μόνο για την εμφάνισή τους", το πρόγραμμα δεν πραγματοποιεί στατιστικούς ελέγχους στους λίγους αριθμούς που αποθηκεύει, και όπως εξηγήθηκε προηγουμένως η υλοποίηση όλων των στατιστικών ελέγχων είναι σχεδιασμένη για να δέχεται τους αριθμούς σταδιακά. Μια υλοποίηση της εμφάνισης των εκατό αριθμών χωρίς ενδιάμεση αποθήκευση θα αύξανε σημαντικά την πολυπλοκότητα του προγράμματος και θα μείωνε την αναγνωσιμότητα του πηγαίου κώδικα.

## Ο πηγαίος κώδικας

``` csharp
// Source code goes here
```
