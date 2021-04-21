%%%% Κώδικας από το Open eClass
:-op(450,yfx,and).
:-op(500,yfx,or).
:-op(500,yfx,nor).
:-op(450,yfx,nand).
:-op(500,yfx,xor).

:-op(400,fy,--).
:-op(600,xfx,==>).



--Arg1:-not(Arg1).

Arg1 ==> Arg2 :- --Arg1 or Arg2.

Arg1 and Arg2 :- Arg1, Arg2.

Arg1 or _Arg2 :- Arg1.
_Arg1 or Arg2 :- Arg2.

Arg1 xor Arg2 :- Arg1, --Arg2.
Arg1 xor Arg2 :- --Arg1, Arg2.

Arg1 nor Arg2 :- --(Arg1 or Arg2).
Arg1 nand Arg2 :- --(Arg1 and Arg2).


t.
f:-!,fail.

%%%% Κώδικας της άσκησης
list_forall([], _).
list_forall([X|Xs], F) :-
    Exp =.. [F, X],
    call(Exp),
    list_forall(Xs, F).

is_boolean(t).
is_boolean(f).

model(Term) :-
    term_variables(Term, Vars),
    list_forall(Vars, is_boolean),
    call(Term).

concatenate_boolean([X], X).
concatenate_boolean([X1,X2|Xs], Result) :-
    concatenate_boolean([X1 and X2|Xs], Result).

theory(Terms) :-
    concatenate_boolean(Terms, TermConcatenated),
    model(TermConcatenated).

seperate_lists(List, Lets, Nums) :-
    findall(X, (member(X, List), not(number(X))), Lets),
    findall(X, (member(X, List), number(X)), Nums).
