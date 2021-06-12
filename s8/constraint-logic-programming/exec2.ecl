:- lib(ic).
:- lib(ic_edge_finder).
:- lib(ic_global).
:- lib(branch_and_bound).

ram([2,8,8,16,2,4]).
price([30,35,20,38,44,65]).
vcpu([4,8,8,4,4,8]).

select_providers(Prov1, Prov2, Price) :-
    ram(Rams),
    price(Prices),
    vcpu(VCpus),

    element(Prov1, Rams, Ram1),
    element(Prov1, Prices, Price1),
    element(Prov1, VCpus, VCpu1),

    element(Prov2, Rams, Ram2),
    element(Prov2, Prices, Price2),
    element(Prov2, VCpus, VCpu2),

    Prov1 #< Prov2,
    Ram1 #>= 4, Ram2 #>= 4,
    VCpu1 + VCpu2 #= 12,
    Price #= Price1 + Price2,

    bb_min(labeling([Prov1, Prov2]), Price, bb_options{strategy:restart, solutions:all}).


class(clp,3,40,3).
class(procedural,3,60,2).
class(analysis,4,50,2).
class(computer_sys,4,40,3).
class(algebra,3,40,4).

apply_lectures_constrs([], [], []).
apply_lectures_constrs([Start|Starts], [Duration|Durations], [End|Ends]) :-
    End #= Start + Duration,
    apply_lectures_constrs(Starts, Durations, Ends).

lectures(Classes, Starts, Makespan) :-
    findall(X, class(X, _, _, _), Classes),
    findall(X, class(_, X, _, _), Durations),
    findall(X, class(_, _, X, _), ZoomLicenses),
    findall(X, class(_, _, _, X), RequiredProfessors),

    length(Classes, N),
    length(Starts, N),
    Starts #:: 9..inf,
    apply_lectures_constrs(Starts, Durations, Ends),
    ic:maxlist(Ends, Makespan),
    cumulative(Starts, Durations, ZoomLicenses, 100),
    cumulative(Starts, Durations, RequiredProfessors, 6),

    bb_min(labeling(Starts), Makespan, bb_options{strategy:restart, solutions:all}).


product(a,40).
product(b,56).
product(c,48).
product(d,64).

apply_company_constrs([], [], [], [], [], []).
apply_company_constrs([Product|Products], [S|Ss], [D|Ds], [RealD|RealDs], [Machine|Machines], [End|Ends]) :-
    D #= Product / Machine,
    RealD #= 15 + D,
    End #= S + RealD,
    apply_company_constrs(Products, Ss, Ds, RealDs, Machines, Ends).

company(st(S), dur(D), machines(Machines), M) :-
    findall(X, product(_, X), Products),
    length(Products, N),
    length(S, N),
    S #:: 0..inf,
    length(Machines, N),
    Machines #:: 2..8,
    length(QCMachines, N),
    QCMachines #:: 1,
    apply_company_constrs(Products, S, D, RealD, Machines, Ends),
    M #= max(Ends) - 15,
    cumulative(S, RealD, Machines, 8),
    cumulative(S, RealD, QCMachines, 2),

    bb_min(labeling([S, Machines]), M, bb_options{strategy:restart, solutions:all}).
