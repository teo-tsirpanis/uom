command(add_r1, state(acc(X), reg1(Y), R2, R3), state(acc(X + Y), reg1(Y), R2, R3)).
command(add_r2, state(acc(X), R1, reg2(Y), R3), state(acc(X + Y), R1, reg2(Y), R3)).
command(add_r3, state(acc(X), R1, R2, reg3(Y)), state(acc(X + Y), R1, R2, reg3(Y))).
command(subtract_r1, state(acc(X), reg1(Y), R2, R3), state(acc(X - Y), reg1(Y), R2, R3)).
command(subtract_r2, state(acc(X), R1, reg2(Y), R3), state(acc(X - Y), R1, reg2(Y), R3)).
command(subtract_r3, state(acc(X), R1, R2, reg3(Y)), state(acc(X - Y), R1, R2, reg3(Y))).
command(store_r1, state(acc(X), _, R2, R3), state(acc(X), reg1(X), R2, R3)).
command(store_r2, state(acc(X), R1, _, R3), state(acc(X), R1, reg2(X), R3)).
command(store_r3, state(acc(X), R1, R2, _), state(acc(X), R1, R2, reg3(X))).
command(load_r1, state(_, reg1(X), R2, R3), state(acc(X), reg1(X), R2, R3)).
command(load_r2, state(_, R1, reg2(X), R3), state(acc(X), R1, reg2(X), R3)).
command(load_r3, state(_, R1, R2, reg3(X)), state(acc(X), R1, R2, reg3(X))).

initialState(state(acc(c1), reg1(0), reg2(c2), reg3(c3))).
% Επειδή στο σχήμα φαινόταν μόνο η τελική κατάσταση του καταχωρητή 1 και δε γίνεται
% να αλλάξει μόνο αυτός και να μείνουν οι υπόλοιποι ίδιοι, υποθέτουμε ότι η τιμή
% των άλλων καταχωρητών δε μας νοιάζει.
finalState(reg1(c1 - c2 + c3)).

findOps(O1, O2, O3) :-
    initialState(_S0),
    command(O1, _S0, _S1),
    command(O2, _S1, _S2),
    command(O3, _S2, state(_, _R1_3, _, _)),
    finalState(_R1_3).
