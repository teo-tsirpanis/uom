module LinearProgrammingProblemParser.Formatter

open System.Text
open LinearProgrammingProblemParser.DomainTypes

let private formatExpression xChar (Expression x) =
    match x with
    | x :: xs ->
        let sb = StringBuilder()
        let formatVariable x =
            let (Variable (k, X x)) = x
            Printf.bprintf sb "%g%c%d" (abs k) xChar x
        formatVariable x
        List.iter (fun (Variable (k, _) as v) ->
            if k < 0.0 then
                " - "
            else
                " + "
            |> sb.Append |> ignore
            formatVariable v) xs
        sb.ToString()
    // Ο parser δε θα αναγνώριζε έναν περιορισμό του
    // τύπου 0 <= 5. Η πρώτη μεταβλητή υπάρχει πάντα άλλωστε.
    | [] -> sprintf "0%c1" xChar

let private formatConstraint xChar x =
    match x with
    | Constraint.LessThanOrEqual(x, n) ->
        sprintf "%s <= %g" (formatExpression xChar x) n
    | Constraint.Equal(x, n) ->
        sprintf "%s = %g" (formatExpression xChar x) n
    | Constraint.GreaterThanOrEqual(x, n) ->
        sprintf "%s >= %g" (formatExpression xChar x) n

let private makeConstraintsFromMatrices a b eqin =
    let m = Array2D.length1 a
    let n = Array2D.length2 a
    List.init m (fun i ->
        let mutable xs = []
        for j = n - 1 downto 0 do
            let v = a.[i, j]
            if v <> 0.0 then
                xs <- Variable(v, X(j + 1)) :: xs
        let expr = Expression xs
        let rhs = Array.get b i
        match Array.get eqin i with
        | 0 -> Constraint.Equal(expr, rhs)
        | x when x > 0 -> Constraint.GreaterThanOrEqual(expr, rhs)
        | _ -> Constraint.LessThanOrEqual (expr, rhs)
    )

let private makeObjectiveFunction c =
    let mutable xs = []
    for i = Array.length c - 1 downto 0 do
        let v = c.[i]
        if v <> 0.0 then
            xs <- Variable(v, X(i + 1)) :: xs
    Expression xs

/// Η συνάρτηση αυτή παίρνει ένα γραμμικό πρόβλημα με πίνακες
/// και το μετατρέπει σε μια μορφή κειμένου εύκολα αναγνώσιμη.
/// Η πρώτη παράμετρος παίρνει έναν χαρακτήρα που θα συμβολίζει
/// τις μεταβλητές του προβλήματος. Παρουσιάζοντας δυικά προβλήματα
/// μπορεί να τεθεί σε 'w' για καλύτερη παρουσίαση.
/// Αν η πρώτη παράμετρος τεθεί σε 'x' και εξαιρώντας τους φυσικούς περιορισμούς
/// στο τέλος, το παραχθέν κείμενο μπορεί να διαβαστεί από τον parser.
let formatLPPWithMatrices xChar {A = a; b = b; c = c; Eqin = eqin; MinMax = minMax; NatConstrs = natConstrs} =
    let sb = StringBuilder()
    if minMax > 0 then
        "max "
    elif minMax < 0 then
        "min "
    else
        failwith "Invalid linear program. MinMax must not be equal to zero."
    |> sb.Append |> ignore

    c
    |> makeObjectiveFunction
    |> formatExpression xChar
    |> sb.AppendLine |> ignore
    sb.AppendLine() |> ignore

    sb.AppendLine "st" |> ignore
    makeConstraintsFromMatrices a b eqin
    |> List.iter (formatConstraint xChar >> sb.AppendLine >> ignore)
    sb.AppendLine() |> ignore

    natConstrs
    |> Seq.mapi (fun i x -> i + 1, x)
    |> Seq.groupBy snd
    |> Seq.iter (fun (constraintType, xs) ->
        xs
        |> Seq.map (fst >> sprintf "%c%d" xChar)
        |> String.concat ", "
        |> sb.Append |> ignore

        if constraintType > 0 then
            " >= 0"
        elif constraintType < 0 then
            " <= 0"
        else
            " free"
        |> sb.AppendLine |> ignore)

    sb.ToString()
