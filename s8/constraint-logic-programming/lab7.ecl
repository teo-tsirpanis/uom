:- lib(ic).
:- lib(ic_global).
:- lib(branch_and_bound).

provider(a,[0,750,1000,1500],[0,10,13,17]).
provider(b,[0,500,1250,2000],[0,8,12,22]).
provider(c,[0,1000,1750,2000],[0,15,18,25]).
provider(d,[0,1000,1500,1750],[0,13,15,17]).

make_constraints([], [], 0).
make_constraints([Prov|Provs], [Cap|Caps], Cost) :-
    provider(Prov, Capacities, Costs),
    element(I, Capacities, Cap),
    element(I, Costs, Cst),
    make_constraints(Provs, Caps, RestCost),
    Cost #= RestCost + Cst.

space(Capacities, Cost) :-
    findall(ProvId, provider(ProvId, _, _), Provs),
    make_constraints(Provs, Capacities, Cost),
    TotalCapacity #:: [3600 .. 4600],
    sumlist(Capacities, TotalCapacity),
    bb_min(labeling(Capacities), Cost, _).
