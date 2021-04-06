common_suffix(X, Y, Suffix, Pos) :-
    append(_, Suffix, X),
    append(_, Suffix, Y),
    length(Suffix, Pos).
