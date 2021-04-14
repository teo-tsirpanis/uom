seperate_lists([], [], []).
seperate_lists([X|Xs], Lets, [X|Nums]) :-
    number(X),
    !,
    seperate_lists(Xs, Lets, Nums).
seperate_lists([X|Xs], [X|Lets], Nums) :-
    seperate_lists(Xs, Lets, Nums).

whitelist_op(X1, min, X2, R) :- min(X1, X2, R).
whitelist_op(X1, max, X2, R) :- max(X1, X2, R).

max_min_eval([X], X).
max_min_eval([X1,Op,X2|Xs], Result) :-
    whitelist_op(X1, Op, X2, ExprResult),
    max_min_eval([ExprResult|Xs], Result).
