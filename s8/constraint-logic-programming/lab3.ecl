contains(_, [], false).
contains(X, [X|_], true).
contains(X, [Y|Xs], Result) :-
    X \= Y,
    contains(X, Xs, Result).

% Αν στην αρχική λίστα υπήρχε ήδη το X, δε θα εμφανίσουμε σαν
% αποτέλεσμα την ίδια αρχική λίστα χωρίς καμία αντικατάσταση.
replace_impl(_, _, [], [], false).

replace_impl(X, Y, [X|Xs], [Y|Xs], _).

replace_impl(X, Y, [Z|Xs], [Z|XsNew], ContainsX) :-
    replace_impl(X, Y, Xs, XsNew, ContainsX).

replace(X, Y, Xs, XsNew) :-
    contains(X, Xs, ContainsX),
    replace_impl(X, Y, Xs, XsNew, ContainsX).
