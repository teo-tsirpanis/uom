@REM Το σενάριο αυτό μεταγλωττίζει και μετά εκτελεί το πρόγραμμα
@REM που σημαίνει ότι αν εκτελεστεί πολλές φορές θα ξεκινήσει γρηγορότερα.
@REM Το -c Release ενεργοποιεί όλες τις βελτιστοποιήσεις για την αποδοτικότερη
@REM ταχύτητα εκτέλεσης.

dotnet run -c Release -- %*