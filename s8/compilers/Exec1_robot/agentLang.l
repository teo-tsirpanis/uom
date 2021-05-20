/* This is an example of a simple LL grammar implementation */
%{
#include <stdio.h>
#include <string.h>



/* Needed for syntax analyser*/
#define LEXEND 0
#define T_NAME 301
#define T_OP 302
#define T_SENSOR 303
#define T_NUM 304
#define T_VAR 305
#define T_INIT 306
#define T_NOINIT 307
#define T_ARROW 308
#define T_MOVE 309
#define T_TURN 310
#define T_STAY 311
#define T_FORWARD 312
#define T_LEFT 313
#define T_RIGHT 314
#define T_BRLEFT 315
#define T_BRRIGHT 316
#define T_TRUE 317

int line = 1;
%}

uppercase [A-Z]
lowercase [a-z]
digit [0-9]
newline \n|\r|\r\n
%%

"{" {return T_BRLEFT;}
"}" {return T_BRRIGHT;}
">"|"<"|"=" {return T_OP;}
"left-laser"|"right-laser"|"front-sonar" {return T_SENSOR;}
"init" {return T_INIT;}
"no-init" {return T_NOINIT;}
"=>" {return T_ARROW;}
"move" {return T_MOVE;}
"turn" {return T_TURN;}
"stay" {return T_STAY;}
"forward" {return T_FORWARD;}
"left" {return T_LEFT;}
"right" {return T_RIGHT;}
"true" {return T_TRUE;}
{lowercase}+ {return T_NAME;}
{digit}+ {return T_NUM;}
{uppercase}{lowercase}* {return T_VAR;}
{newline} { line++; }
. {/* Do Nothing */}
%%

int token = 0;

void agent(void);
void rules(void);
void recursiveRules(void);
void rule(void);
void sensorRule(void);
void action(void);
void turnAction(void);
void amount(void);

void error_syntax(void);
void match(int tk);

#define ELSE_FAIL else error_syntax()

void agent(){
   if (token == T_NAME) {
      match(T_NAME);
      match(T_BRLEFT);
      rules();
      match(T_BRRIGHT);
   } ELSE_FAIL;
}

void rules() {
   if (token == T_INIT || token == T_NOINIT) {
      // Αντί για ξεχωριστά μονοπάτια για το T_INIT και το
      // T_NOINIT, τα συγχωνεύουμε σε ένα για εξοικονόμηση κώδικα.
      // Δε μας νοιάζει η σημασιολογική τους ερμηνεία, κάνουμε
      // συντακτικό έλεγχο, όχι ανάλυση. Το ίδιο συμβαίνει επίσης
      // και σε άλλα μη τερματικά.
      match(token);
      recursiveRules();
   } ELSE_FAIL;
}

void recursiveRules() {
   if (token == T_SENSOR || token == T_TRUE) {
      rule();
      recursiveRules();
   } else if (token != T_BRRIGHT)
      error_syntax();
}

void rule() {
   if (token == T_SENSOR) {
      match(T_SENSOR);
      match(T_OP);
      sensorRule();
   } else if (token == T_TRUE) {
      match(T_TRUE);
      match(T_ARROW);
      action();
   } ELSE_FAIL;
}

void sensorRule() {
   if (token == T_NUM || token == T_VAR) {
      match(token);
      match(T_ARROW);
      action();
   } ELSE_FAIL;
}

void action() {
   if (token == T_MOVE) {
      match(T_MOVE);
      match(T_FORWARD);
      amount();
   } else if (token == T_TURN) {
      match(T_TURN);
      turnAction();
   } else
      match(T_STAY);
}

void turnAction() {
   if (token == T_LEFT || token == T_RIGHT) {
      match(token);
      amount();
   } ELSE_FAIL;
}

void amount() {
   if (token == T_NUM || token == T_VAR)
      match(token);
   ELSE_FAIL;
}

void error_syntax(){
   printf(" Syntax Error reading %s at line %d of input. \n",yytext, line);
   exit(-1);
}

void match(int tk){
   if (token == tk) token = yylex();
   else  error_syntax();
}

int main(int argc, char **argv ){
   ++argv, --argc;  /* skip over program name */
   if ( argc > 0 )
      yyin = fopen( argv[0], "r" );
   else
      yyin = stdin;

   token = yylex();
   agent();
   if (token == LEXEND) printf("\n Success! \n \n");
   else error_syntax();
   return 0;
}
