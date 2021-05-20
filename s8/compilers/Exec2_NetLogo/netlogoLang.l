newline \n|\r|\r\n
lowercase [a-z]
letter [a-zA-Z]
number [0-9]

%%

"to" {return T_TO;}
"to-report" {return T_TOREPORT;}
"end" {return T_END;}
"[" {return T_BRLEFT;}
"]" {return T_BRRIGHT;}
"if" {return T_IF;}
"report" {return T_REPORT;}
"(" {return T_PARENLEFT;}
")" {return T_PARENRIGHT;}
"=" {return T_ASG;}
{lowercase}+ {return T_NAME;}
\?{letter}+ {return T_VAR;}
{number}+ {return T_NUM;}
{newline} {yylineno++;}
. {/* Do Nothing */}

%%
