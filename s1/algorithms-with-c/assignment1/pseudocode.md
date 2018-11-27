# Αλγόριθμοι με C: 1η Εργασία, 2018-2019

#### Τσιρπάνης Θεόδωρος (dai19090)

## Ψευδοκώδικας

```
Αλγόριθμος BestTimeToParty
Δεδομένα: ΠΡΟΓΡΑΜΜΑ, πλήθος
Αποτελέσματα: Μέγιστοι_Μεταλλάδες_Ώρα
```
---
```
για ι από 1 μέχρι 24
    ΩΡΕΣ(ι) <- 0
για ι από 1 μέχρι πλήθος
    ΩΡΕΣ(ΠΡΟΓΡΑΜΜΑ(ι, 1)) <- ΩΡΕΣ(ΠΡΟΓΡΑΜΜΑ(ι, 1)) + 1
    ΩΡΕΣ(ΠΡΟΓΡΑΜΜΑ(ι, 2)) <- ΩΡΕΣ(ΠΡΟΓΡΑΜΜΑ(ι, 2)) - 1

Μέγιστοι_Μεταλλάδες_Ώρα <- 1
Τωρινοί_Μεταλλάδες <- ΩΡΕΣ(Μέγιστοι_Μεταλλάδες_Ώρα)
Μέγιστοι_Μεταλλάδες <- Τωρινοί_Μεταλλάδες
για ι από 2 μέχρι 24
    Τωρινοί_Μεταλλάδες <- Τωρινοί_Μεταλλάδες + ΩΡΕΣ(ι)
    αν Τωρινοί_Μεταλλάδες > Μέγιστοι_Μεταλλάδες τότε
        Μέγιστοι_Μεταλλάδες <- Τωρινοί_Μεταλλάδες
        Μέγιστοι_Μεταλλάδες_Ώρα <- ι
```