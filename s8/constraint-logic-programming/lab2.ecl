% Προσφέρονται δύο αναδρομικές υλοποιήσεις της sumn· μια απλή με ένα κατηγόρημα,
% και μια με δυο κατηγορήματα αλλά tail-recursive. Η δεύτερη χρησιμοποιεί έναν
% συσσωρευτή ξεχωριστό από το αποτέλεσμα, και η βασική διαφορά της από την πρώτη
% μπορεί να φανεί αφαιρώντας τον περιορισμό N > 1 και στις δύο υλοποιήσεις, και
% πατώντας "more". Η Prolog θα αρχίσει να ανατρέχει μάταια στους αρνητικούς αριθμούς,
% αλλά η πρώτη υλοποίηση θα σταματήσει κάποτε με stack overflow, ενώ η δεύτερη δε θα
% υπερχειλίσει ποτέ την στοίβα, αλλά θα εκτελείται επ' άπειρον σε έναν ατέρμονα βρόγχο.

sumn_rec(1, 1).

sumn_rec(N, S) :-
    N > 1,
    NN is N - 1,
    sumn_rec(NN, SS),
    S is N + SS.

sumn_tailrec(1, Acc, Acc).

sumn_tailrec(N, Acc, Result) :-
    N > 1,
    NN is N - 1,
    Acc2 is Acc + N,
    sumn_tailrec(NN, Acc2, Result).

sumn(N, S) :- sumn_tailrec(N, 1, S)