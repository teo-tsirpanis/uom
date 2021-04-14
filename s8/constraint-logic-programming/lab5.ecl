seperate_lists([], [], []).
seperate_lists([X|Xs], Lets, [X|Nums]) :-
    number(X),
    !,
    seperate_lists(Xs, Lets, Nums).
seperate_lists([X|Xs], [X|Lets], Nums) :-
    seperate_lists(Xs, Lets, Nums).

max_min_eval([X], X).
max_min_eval([X1,Op,X2|Xs], Result) :-
    Expr =.. [Op, X1, X2, ExprResult],
    call(Expr),
    max_min_eval([ExprResult|Xs], Result).
