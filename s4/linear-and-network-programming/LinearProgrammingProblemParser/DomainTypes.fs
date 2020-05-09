namespace LinearProgrammingProblemParser.DomainTypes

open System.Text

// Ο τύπος Number είναι συνώνυμο του τύπου float.
// Μπορούμε έτσι να αλλάξουμε εύκολα τον τύπο των αριθμών στα γραμμικά προβλήματα.
// Στην F# ο τύπος float είναι διπλής ακρίβειας.
// Απλής ακρίβειας είναι ο τύπος float32.
type Number = float

// Ο τύπος X δηλώνει έναν άγνωστο. Δεν είναι ακέραιος, περιέχει έναν ακέραιο.
// Δε μπορούμε να κάνεις πράξεις με μεταβλητές τύπου X για παράδειγμα. x4 + x5 != x9.
// Ο πρώτος άγνωστος έχει την τιμή 1.
type X = X of int

// Ο τύπος Variable συμβολίζει μια μεταβλητή με έναν συντελεστή της.
type Variable = Variable of coefficient: Number * X

// Ο τύπος Expression συμβολίζει μια έκφταση. Στην ουσία είναι μια λίστα μεταβλητών,
// αλλά όπως με το X, δε μπορείς να ενώσεις δύο εκφράσεις. Πρέπει να πεις ρητά ότι
// ενώνεις τις λίστες των μεταβλητών των εκφράσεων, και παίρνεις μια λίστα μεταβλητών,
// όχι μια έκφραση.
type Expression = Expression of Variable list
with
    member x.Variables = let (Expression x) = x in x

// Οι επόμενοι δύο τύποι είναι προφανές τι συμβολίζουν.
type Objective =
    | Minimize of Expression
    | Maximize of Expression
    member x.Expression =
        match x with
        | Minimize x
        | Maximize x -> x

// Το παρακάτω attribute μας υποχρεώνει να γράψουμε
// Constraint.Equal αντί για σκέτο Equal. Η λέξη Equal
// από μόνη της μπορεί να μπερδέψει τον αναγνώστη.
// Το Objective δεν έχει τέτοιο πρόβλημα.
[<RequireQualifiedAccess>]
type Constraint =
    |    LessThanOrEqual of Expression * Number
    |              Equal of Expression * Number
    | GreaterThanOrEqual of Expression * Number
    member x.Expression =
        match x with
        |    LessThanOrEqual (x, _)
        |              Equal (x, _)
        | GreaterThanOrEqual (x, _) -> x
    member x.Value =
        match x with
        |    LessThanOrEqual (_, x)
        |              Equal (_, x)
        | GreaterThanOrEqual (_, x) -> x

// Το γραμμικό πρόβλημα, όπως το διαβάζει ο parser.
type LPP = {
    Objective: Objective
    // Η λίστα μπορεί να είναι άδεια, αλλά ο parser δε θα το επιτρέψει.
    Constraints: Constraint list
}

// Το γραμμικό πρόβλημα, όπως το θέλουν οι λύτες και η εκφώνηση.
// Εδώ έχουμε πίνακες, όχι συνδεδεμένες λίστες.
type LPPWithMatrices = {
    A: Number [,]
    b: Number []
    c: Number []
    Eqin: int []
    MinMax: int
    /// Οι φυσικοί περιορισμοί της κάθε μεταβλητής.
    /// 0 σημαίνει ελεύθερη μεταβλητή,
    /// αρνητική τιμή σημαίνει αρνητική μεταβλητή κοκ.
    NatConstrs: int []
}
with
    // Αυτή η συνάρτηση μετατρέπει ένα πρόβλημα από
    // τον τύπο LPP στον τύπο LPPWithMatrices.
    static member Create {Objective = objective; Constraints = constraints} =
        // Αυτό λέγεται ενεργό μοτίβο (active pattern).
        // Επιστρέφει τον δείκτη ξεκινώντας από το 0.
        let (|XZeroBased|) (X x) = x - 1
        // Πρώτα πρέπει να βρούμε πόσους αγνώστους έχουμε για να ξέρουμε το μέγεθος των πινάκων μας.
        let numberOfUnknowns =
            // Βλέπουμε τον μεγαλύτερο άγνωστο στους περιορισμούς.
            let constrMax =
                constraints
                // Η collect αντιστοιχεί κάθε στοιχείο μιας
                // ακολουθίας σε μια άλλη ακολουθία
                // και τις ενώνει όλες μαζί.
                // Εδώ βάζει σε μια ακολουθία όλες τις μεταβλητές του κάθε περιορισμού.
                // Χρησιμοποιούμε οκνηρά αποτιμημένες (lazily evaluated)
                // ακολουθίες για εξοικονόμηση μνήμης.
                |> Seq.collect (fun x -> x.Expression.Variables)
                // Η map αντιστοιχεί κάθε στοιχείο μιας ακολουθίας σε κάποιο άλλο.
                // Το x στην παρακάτω γραμμή είναι με βάση το ένα.
                |> Seq.map (fun (Variable (_, X x)) -> x)
                |> Seq.max
            // Και στην αντικειμενική συνάρτηση.
            let objMax =
                objective.Expression.Variables
                |> Seq.map (fun (Variable (_, X x)) -> x)
                |> Seq.max
            // Και παίρνουμε το μεγαλύτερο από τα δύο.
            // Αν ο μεγαλύτερος άγνωστος που δούμε είναι ο x5, έχουμε 5 αγνώστους.
            max constrMax objMax

        let A =
            // Ξέρουμε τις διαστάσεις του πίνακα. Το μήκος των περιορισμών
            // χρειάζεται χρόνο Ο(n), μιας και είμαστε σε συνδεδεμένη λίστα,
            // αλλά δε πειράζει. Τα στοιχεία του πίνακα είναι μηδέν αρχικά.
            let A = Array2D.zeroCreate constraints.Length numberOfUnknowns
            constraints
            // Η συνάρτηση iteri εφαρμόζει μια συνάρτηση σε κάθε στοιχείο
            // της λίστας, περνώντας και τη θέση του στοιχείου αυτού.
            |> List.iteri (fun idx x ->
                x.Expression.Variables
                // Η συνάρτηση iter είναι σαν την iteri, αλλά χωρίς να
                // περνά τη θέση. Βλέπουμε επίσης πώς χρησιμοποιούνται τα
                // ενεργά μοτίβα. Ανί για X, γράψαμε XZeroBased, και η τιμή
                // x είναι με βάση το μηδέν αυτή τη φορά.
                |> List.iter (fun (Variable(var, XZeroBased x)) ->
                    // Κάνουμε πρόσθεση και όχι ανάθεση για να
                    // χειριστούμε την περίπτωση που μας δώσουν 5x2 + 5x2.
                    A.[idx, x] <- A.[idx, x] + var))
            // Το A είναι έτοιμο, και το επιστρέφουμε.
            A

        // Το b είναι εκπληκτικά απλό: από κάθε περιορισμό παίρνουμε την τιμή του
        // και δημιουργούμε έναν μονοδιάστατο πίνακα. Δε χρειάζεται καν να πούμε
        // ρητά το μέγεθός του.
        let b = constraints |> Seq.map (fun x -> x.Value) |> Array.ofSeq
        // Με το c ισχύουν τα ίδια που είχαμε πει και για το A.
        let c =
            let c = Array.zeroCreate numberOfUnknowns
            objective.Expression.Variables
            |> List.iter (fun (Variable (var, XZeroBased x)) -> c.[x] <- c.[x] + var)
            c

        let Eqin =
            constraints
            |> Seq.map (
                // Αντί να γράψουμε fun x -> match x with ...,
                // μπορούμε να γράψουμε μόνο τη λέξη function.
                function
                | Constraint.LessThanOrEqual    _ -> -1
                | Constraint.Equal              _ ->  0
                | Constraint.GreaterThanOrEqual _ ->  1)
            |> Array.ofSeq
        // Κατευθείαν από την εκφώνηση.
        let MinMax =
            match objective with
            | Minimize _ -> -1
            | Maximize _ ->  1
        // Στα προβλήματα του χρήστη, οι μεταβλητές
        // θα θεωρούνται πάντα ότι είναι θετικές.
        let NatConstrs = Array.create numberOfUnknowns 1

        // Φτιάξαμε όλα τα συστατικά του γραμμικού προβλήματος,
        // και τώρα θα τα ενώσουμε στον τελικό τύπο που θα επιστρέψουμε.
        {
            A = A
            b = b
            c = c
            Eqin = Eqin
            MinMax = MinMax
            NatConstrs = NatConstrs
        }
    /// Η συνάρτηση αυτή επιστρέφει το δυικό αυτού του προβλήματος.
    member this.Dual() =
        let AT =
            let A = this.A
            Array2D.init (Array2D.length2 A) (Array2D.length1 A) (fun j i -> A.[i, j])
        {
            A = AT
            // Καλύτερα να μην γράψουμε b = c. Ο ίδιος πίνακας θα υπήρχε
            // σε πολλά αντικείμενα και θα μπορούσε να τροποποιηθεί απρόβλεπτα.
            // Επίσης, το ότι ο ένας μονοδιάστατος πίνακας είναι πίνακας γραμμή
            // και ο άλλος  είναι πίνακες στήλη είναι μια μαθηματικά τυπική
            // λεπτομέρεια που δεν αλλάζει τον τρόπο αποθήκευσής τους στην μνήμη.
            b = Array.copy this.c
            c = Array.copy this.b
            // Πολλαπλασιάζουμε το κάθε στοιχείο με το -MinMax.
            // Δηλαδή οι τιμές αλλάζουν πρόσημο στο δυικό ενός
            // προβλήματος μεγιστοποίησης.
            Eqin = Array.map ((*) -this.MinMax) this.NatConstrs
            MinMax = -this.MinMax
            // Πολλαπλασιάζουμε το κάθε στοιχείο με το MinMax.
            // Δηλαδή οι τιμές αλλάζουν πρόσημο στο δυικό ενός
            // προβλήματος ελαχιστοποίησης.
            NatConstrs = Array.map ((*) this.MinMax) this.Eqin
        }
