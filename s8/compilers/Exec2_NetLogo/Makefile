default: netlogo-lexer netlogo-parser
	gcc netlogo.tab.c -o netlogo -lfl

netlogo-lexer: netlogoLang.l
	flex -o netlogo.lex.c netlogoLang.l

netlogo-parser: netlogoLang.y
	bison -v -o netlogo.tab.c netlogoLang.y 

clean:
	rm -f netlogo
	rm -f netlogo.lex.c
	rm -f netlogo.tab.c
	rm -f netlogo.output
