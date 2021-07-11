/*
	Validating Propositional (Boolean) Satisfiability problems.

	Ioannis Refanidis, 2009
*/

#include <stdio.h>
#include <stdlib.h>

int N;			// Number of propositions
int M;			// Number of sentences
int K;			// Number of propositions per sentence

int *Problem;	// This is a table to keep all the sentences of the problem

int *vector;

// Reading the input file
int readfile(char *filename) {
	int i,j;

	FILE *infile;
	int err;
	
	// Opening the input file
	infile=fopen(filename,"r");
	if (infile==NULL) {
		printf("Cannot open input file. Now exiting...\n");
		fclose(infile);
		return -1;
	}

	// Reading the number of propositions
	err=fscanf(infile, "%d", &N);
	if (err<1) {
		printf("Cannot read the number of propositions. Now exiting...\n");
		fclose(infile);
		return -1;
	}

	if (N<1) {
		printf("Small number of propositions. Now exiting...\n");
		fclose(infile);
		return -1;
	}

	// Reading the number of sentences
	err=fscanf(infile, "%d", &M);
	if (err<1) {
		printf("Cannot read the number of sentences. Now exiting...\n");
		fclose(infile);
		return -1;
	}

	if (M<1) {
		printf("Low number of sentences. Now exiting...\n");
		fclose(infile);
		return -1;
	}

	// Reading the number of propositions per sentence
	err=fscanf(infile, "%d", &K);
	if (err<1) {
		printf("Cannot read the number of propositions per sentence. Now exiting...\n");
		fclose(infile);
		return -1;
	}

	if (K<2) {
		printf("Low number of propositions per sentence. Now exiting...\n");
		fclose(infile);
		return -1;
	}

	// Allocating memory for the sentences...
	Problem=(int*) malloc(M*K*sizeof(int));

	// ...and read them
	for (i=0;i<M;i++)
		for(j=0;j<K;j++) {
			err=fscanf(infile,"%d", Problem+i*K+j);
			if (err<1) {
				printf("Cannot read the #%d proposition of the #%d sentence. Now exiting...\n",j+1,i+1);
				fclose(infile);
				return -1;
			}
			if (Problem[i*K+j]==0 || Problem[i*K+j]>N || Problem[i*K+j]<-N) {
				printf("Wrong value for the #%d proposition of the #%d sentence. Now exiting...\n",j+1,i+1);
				fclose(infile);
				return -1;
			}
		}

	fclose(infile);

	return 0;
}

// Reading the solution file. Note that this file should have at least N integers with -1/+1 values.
int *read_solution(char **argv) {
	FILE *infile;
	int *vector;
	int i,err;
	
	infile=fopen(argv[2],"r");
	if (infile==NULL) {
		printf("Cannot open solution file. Now exiting...");
		return NULL;
	}

	vector=(int*) malloc(N*sizeof(int));
	if (vector==NULL){
		printf("Cannot allocate memory for the solution vector. Now exiting...\n");
		return NULL;
	}

	for(i=0;i<N;i++){
		err=fscanf(infile,"%d",vector+i);
		if (err<1) {
			printf("Cannot read the value of the #%d proposition in the solution file. Now exiting...\n",i+1);
			free(vector);
			return NULL;
		}
	}

	fclose(infile);

	return vector;
}


// This function checks whether a current partial assignment is already invalid. 
// In order for a partial assignment to be invalid, there should exist a sentence such that
// all propositions in the sentence have already value and their values are such that 
// the sentence is false.
int valid(int *vector){
	int i,j;
	for(i=0;i<M;i++)
	{
		int satisfiable=0;
		for(j=0;j<K;j++)
			if ((Problem[i*K+j]>0 && vector[Problem[i*K+j]-1]>=0) 
				||
				(Problem[i*K+j]<0 && vector[-Problem[i*K+j]-1]<=0))
				satisfiable=1;
		if (satisfiable==0)
			return 0;
	}
	return 1;
}

// Check whether a vector is a complete assignment and it is also valid.
int solution(int *vector)
{
	int i;
	for(i=0;i<N;i++)
		if (vector[i]==0)
			return 0;

	return valid(vector);
}

// For a filename containing the entire path (including many [back]slashes, 
// this function returns a pointer to the first char after the last slash of the filename.
char *last_slash(char *s){
	char *last=s, *c=s;
	while (*c!='\0') {
		if (*c=='\\' || *c=='/')
			last=c;
		c++;
	}
	return last+1;
}

void syntax_error(char **argv){
	printf("Use syntax:\n\n");
	printf("%s <problem> <solution>\n\n", last_slash(argv[0]));
	printf("where:\n");
	printf("<problem> is the name of a file containing a problem description\n");
	printf("<solution> is the name of a file containing a vector with values for the propositions of the problem\n");
}

int main(int argc, char **argv) {
	int err;
	int *vector;

	if (argc!=3) {
		syntax_error(argv);
		return -1;
	}

	err=readfile(argv[1]);
	if (err<0)
		return -1;

	vector=read_solution(argv);
	if (vector==NULL)
		return -1;

	err=solution(vector);

	if (err==1)
		printf("ok!\n");
	else
		printf("Error\n");

	return 0;
}