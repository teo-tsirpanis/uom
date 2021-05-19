# ΓΛώσσες Προγραμματισμού & Μεταγλωττιστές - Εργασία 1

### Τσιρπάνης Θεόδωρος, `dai19090`

## Άσκηση 1

Η γραμματική θα υποστεί διάφορα στάδια μετασχηματισμών μέχρι να γίνει ικανή για χρήση από τον αλγόριθμο LL. Τό λεκτικό και συντακτικό μέρος των γραμματικών αναπαρίσταται με μια μορφή ψευδογλώσσας.

### Αρχική γραμματική

```
%case sensitive
%token name /[a-z]+
%token Op /[<>=]
%token sensor /left-laser|right-laser|front-sonar
%token T_NUM /\d+
%token T_VAR /[A-Z][A-Za-z]*

%start Agent

Agent: name '{' Rules '}';

Rules: Rules Rule | 'init' | 'no-init';

Rule: sensor Op T_NUM '=>' Action
    | sensor Op T_VAR '=>' Action
    | 'true' '=>' Action;

Action: 'move' 'forward' T_NUM
      | 'move' 'forward' T_VAR
      | 'turn' 'left' T_NUM
      | 'turn' 'left' T_VAR
      | 'turn' 'right' T_NUM
      | 'turn' 'right' T_VAR
      | 'stay';
```

### Παραγοντοποίηση

Τα μη τερματικά `Rule` και `Action` έχουν παραγωγές με κοινά στοιχεία στην αρχή τους και θα συγχωνευτούν. Τα στοιχεία της γραμματικής που δεν αλλάζουν δεν επαναλαμβάνονται.

```
Rule: sensor Op SensorRule
    | 'true' '=>' Action;

SensorRule: T_NUM '=>' Action
          | T_VAR '=>' Action;

Action: 'move' 'forward' Amount
      | 'turn' TurnAction
      | 'stay';

TurnAction: 'left' Amount
          | 'right' Amount;

Amount: T_NUM | T_VAR;
```

> __Σημείωση:__ Τρία μη-τερματικά της γραμματικής συγχωνεύθηκαν σε ένα για την απλοποίηση της γραμματικής και της μελλοντικής υλοποίησής της. Δε χάνεται η σημασιολογική αξία τους· ένας συντακτικός αναλυτής θα μπορεί πάλι να αξιοποιήσει σωστά την αριθμητική ποσότητα.

### Απαλοιφή Αριστερής Αναδρομής

Το μη τερματικό `Rules` είναι αριστερά αναδρομικό και θα διασπαστεί σε δύο σύμφονα με τη θεωρία.

```
Rules: 'init' RecursiveRules
     | 'no-init' RecursiveRules;

RecursiveRules: Rule RecursiveRules
              | ;
```

### Πλήρης Γραμματική

```
%case sensitive
%token name /[a-z]+
%token Op /[<>=]
%token sensor /left-laser|right-laser|front-sonar
%token T_NUM /\d+
%token T_VAR /[A-Z][A-Za-z]*

%start Agent

Agent: name '{' Rules '}';

Rules: 'init' RecursiveRules
     | 'no-init' RecursiveRules;

RecursiveRules: Rule RecursiveRules
              | ;

Rule: sensor Op SensorRule
    | 'true' '=>' Action;

SensorRule: T_NUM '=>' Action
          | T_VAR '=>' Action;

Action: 'move' 'forward' Amount
      | 'turn' TurnAction
      | 'stay';

TurnAction: 'left' Amount
          | 'right' Amount;

Amount: T_NUM | T_VAR;
```

### Υπολογισμός Συνόλων

||__FIRST__|__FOLLOW__|
|-|-|-|
|`Agent`|`name`|_EOF_|
|`Rules`|`'init'`, `'no-init'`|`'}'`|
|`RecursiveRules`|`sensor`, `'true'`, _ε_|`'}'`|
|`Rule`|`sensor`, `'true'`|`sensor`, `'true'`, `'}'`|
|`SensorRule`|`T_NUM`, `T_VAR`|`sensor`, `'true'`, `'}'`|
|`Action`|`'move'`, `'turn'`, `'stay'`|`sensor`, `'true'`, `'}'`|
|`TurnAction`|`'left'`, `'right'`|`sensor`, `'true'`, `'}'`|
|`Amount`|`T_NUM`, `T_VAR`|`sensor`, `'true'`, `'}'`|

### Υλποποίηση με το Flex

Η υλοποίηση του συντακτικού αναλυτή σε C με τη βοήθεια του εργαλείου Flex επισυνάπτεται μαζί με την εργασία.
