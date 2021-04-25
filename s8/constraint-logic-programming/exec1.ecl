%%% Code for coursework 1 - 2021
%% Exec 1 Lists
%% Add your code here

list_replicate(0, _, []).
list_replicate(Count, X, [X|Xs]) :-
    Count > 0,
    Count2 is Count - 1,
    list_replicate(Count2, X, Xs).

extend([], []).
extend([(0, _)|Xs], Results) :-
    extend(Xs, Results).
extend([(Count, X)|Xs], [Result|Results]) :-
    Count > 0,
    list_replicate(Count, X, Result),
    extend(Xs, Results).

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%% Exec2 Flights 
%%% flight/5
% flight(Code,fromto(Dep,Dest),etd(Time),eta(Time),cost(Cost)).

flight(oa123,fromto(skg,ath),etd(10),eta(11),cost(120)).
flight(oa124,fromto(skg,ath),etd(12),eta(13),cost(80)).
flight(oa125,fromto(skg,ath),etd(13),eta(14),cost(40)).
flight(oa126,fromto(ath,skg),etd(15),eta(16),cost(45)).
flight(oa127,fromto(ath,skg),etd(17),eta(18),cost(45)).
flight(oa120,fromto(skg,lgw),etd(13),eta(14),cost(140)).
flight(aa101,fromto(ath,lgw),etd(15),eta(18),cost(340)).
flight(aa120,fromto(ath,lhr),etd(16),eta(20),cost(120)).
flight(bt190,fromto(ath,lhr),etd(17),eta(21),cost(90)).
flight(bt100,fromto(lgw,ath),etd(18),eta(19),cost(30)).
flight(bt101,fromto(lgw,edi),etd(12),eta(13),cost(30)).
flight(bt110,fromto(lhr,edi),etd(22),eta(23),cost(30)).
flight(lf200,fromto(ath,fra),etd(15),eta(18),cost(550)).
flight(lf201,fromto(fra,ath),etd(20),eta(23),cost(550)).
flight(lf210,fromto(fra,edi),etd(20),eta(22),cost(200)).
flight(lf211,fromto(edi,fra),etd(16),eta(19),cost(190)).

%% Add your code here

find_flight_impl(Src, Src, _Visited, PathAcc, CostAcc, ETA, Path, CostAcc, ETA) :-
    reverse(PathAcc, Path).
find_flight_impl(Src, Dest, Visited, PathAcc, CostAcc, ETALast, Path, Cost, ETAFinal) :-
    Src \= Dest,
    flight(Code, fromto(Src, DestNext), etd(ETD), eta(ETA), cost(FlightCost)),
    not(member(DestNext, Visited)),
    ETALast =< ETD,
    CostAccNew is CostAcc + FlightCost,
    find_flight_impl(DestNext, Dest, [Src|Visited], [Code|PathAcc], CostAccNew, ETA, Path, Cost, ETAFinal).

find_flight(Src, Dest, Path, Cost, ETA) :-
    find_flight_impl(Src, Dest, [Src], [], 0, 0, Path, Cost, ETA).

waiting_time_impl([], WTime, WTime) :-!.
waiting_time_impl([_], WTime, WTime) :-!.
waiting_time_impl([F1|Fs], WTimeAcc, WTime) :-
    Fs = [F2|_],
    flight(F1, _, _, eta(ETA), _),
    flight(F2, _, etd(ETD), _, _),
    WTimeAcc2 is WTimeAcc + ETD - ETA,
    waiting_time_impl(Fs, WTimeAcc2, WTime).

waiting_time(Flights, WTime) :-
    waiting_time_impl(Flights, 0, WTime).

has_min_waiting_time([], _).
has_min_waiting_time([flightplan(Path, _, _)|FlightPlans], MinWait) :-
    waiting_time(Path, WTime),
    MinWait =< WTime,
    has_min_waiting_time(FlightPlans, MinWait).

select_flight(Src, Dest, Path, Before, Cost, MinWait) :-
    findall(flightplan(Path, Cost, ETA), find_flight(Src, Dest, Path, Cost, ETA), FlightPlans),
    member(flightplan(Path, Cost, ETA), FlightPlans),
    ETA =< Before,
    waiting_time(Path, MinWait),
    has_min_waiting_time(FlightPlans, MinWait).

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%% ΕΧEC 3
%%% reduction/2
%% Add your code here

is_unary_op(abs).
eval_unary_op(abs, N, Result) :- abs(N, Result).

is_binary_op(+).
is_binary_op(-).
is_binary_op(*).
is_binary_op(//).
is_binary_op(min).
is_binary_op(max).
eval_binary_op(+, N1, N2, Result) :- Result is N1 + N2.
eval_binary_op(-, N1, N2, Result) :- Result is N1 - N2.
eval_binary_op(*, N1, N2, Result) :- Result is N1 * N2.
eval_binary_op(//, N1, N2, Result) :- Result is N1 // N2.
eval_binary_op(min, N1, N2, Result) :- min(N1, N2, Result).
eval_binary_op(max, N1, N2, Result) :- max(N1, N2, Result).

extract_number([X|Xs], X, Xs) :-
    integer(X).

extract_number([UnaryOp|Xs], Result, Rest) :-
    is_unary_op(UnaryOp),
    extract_number(Xs, N, Rest),
    eval_unary_op(UnaryOp, N, Result).

extract_number([BinaryOp|Xs], Result, Rest) :-
    is_binary_op(BinaryOp),
    extract_number(Xs, N1, Xs2),
    extract_number(Xs2, N2, Rest),
    eval_binary_op(BinaryOp, N1, N2, Result).

reduction(TermsInRPN, Result) :-
    reverse(TermsInRPN, TermsInPN),
    extract_number(TermsInPN, Result, []).
