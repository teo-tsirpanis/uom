# Κατανεμημένα Συστήματα ~ Εργαστήριο 5

### Θοδωρής Τσιρπάνης (`dai19090`)

## Οδηγίες εκτέλεσης

``` bash
cd SigmaBank
```

### Server

``` bash
docker compose up
```

### Client

``` bash
docker build -f ./Client.Dockerfile -t dai19090/sigma-bank-client .
docker run -it --rm --network host dai19090/sigma-bank-client
```

## Περιγραφή

Η πέμπτη εργασία είναι επέκταση της τρίτης. Στο project `SigmaBank.Server.AspNetCore` προστέθηκαν δύο κλάσεις (οι `UsersController` και `AccountsController`) οι οποίες ορίζουν ένα REST API για την αλληλεπίδραση με την τράπεζα.

Επίσης χρησιμοποιείται η τεχνολογία OpenAPI για την τεκμηρίωση του API με τρόπο αναγνώσιμο και από ανθρώπους και από υπολογιστές. Οι άνθρωποι μπορούν να δουν την τεκμηρίωση του API πηγαίνοντας στο http://localhost:6161/swagger/index.html, ενώ οι υπολογιστές πηγαίνοντας στο http://localhost:6161/swagger/v1/swagger.json. Το OpenAPI βοήθησε στην ανάπτυξη του client, παράγοντας αυτόματα το τμήμα του κώδικα που αλληλεπιδρά με τον server στέλνοντας αιτήματα HTTP.

Η συνύπαρξη του REST API με το ήδη υπάρχον gRPC δημιούργησε μια ενδιαφέρουσα επιπλοκή. Το gRPC απαιτεί το πρωτόκολλο HTTP/2 που προσφέρεται στη θύρα 6060, αλλά οι browsers το υποστηρίζουν μόνο με το HTTPS το οποίο δεν υλοποιήθηκε (το .NET δεν έχει πρόβλημα να συνδεθεί με το HTTP/2 χωρίς κρυπτογράφηση). Ούτε γίνεται να υποστηρίζεται και το HTTP/1.1 και το HTTP/2 στην ίδια θύρα επειδή η διαπραγμάτευση της έκδοσης του πρωτοκόλλου γίνεται από το ALPN (Application Layer Protocol Negotiation), μια επέκταση του TLS. Οπότε χρειάστηκε να ανοίξει μια καινούργια θύρα, η 6161 η οποία θα ακούει μόνο πρωτόκολλο HTTP/1.1, επιτρέποντας την κατανάλωση του REST API από τεχνολογίες ιστού.
