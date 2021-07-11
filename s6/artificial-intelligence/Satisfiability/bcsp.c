/*
	Solving the Propositional (Boolean) Satisfiability problem
	using Hill-Climbing and Depth-First Search.

	Ioannis Refanidis, 2009
*/

#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <math.h>
#include <string.h>

#define TIMEOUT		60		// Program terminates after TIMOUT secs

int N;			// Number of propositions
int M;			// Number of sentences
int K;			// Number of propositions per sentence

int *Problem;	// This is a table to keep all the sentences of the problem

// Structure used for the stack of the depth-first search algorithm
struct stack_item {
	int *vector;
	struct stack_item *next;
};

//The head of the stack
struct stack_item *head=NULL;

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

// Auxiliary function that displays all the sentences of the problem
void display_problem() {
	int i,j;

	printf("The current problem:\n");
	printf("====================\n");
	for (i=0;i<M;i++) {
		for(j=0;j<K;j++) {
			if (j>0)
				printf(" or ");
			if (Problem[i*K+j]>0)
				printf("P%d",Problem[i*K+j]);
			else
				printf("not P%d",-Problem[i*K+j]);
		}
		printf("\n");
	}
}

// Initializing a vector of values for the propositions with random values (used by the hill-climbing gready search algorithm)
void initialize(int *vector){
	int i,r;
	for(i=0;i<N;i++)
	{
		r=rand()%100;
		if (r>=50)
			vector[i]=1;
		else
			vector[i]=-1;
	}
#ifdef SHOW_COMMENTS
		printf("*");
#endif
}

// This function counts how many of the sentences are not satisfied by the current assignment of truth values to the propositions.
int count(int *vector){
	int c=0, i, j, satisfied;
	for(i=0;i<M;i++)
	{
		satisfied=0;
		for(j=0;j<K;j++)
			if ((Problem[i*K+j]>0 && vector[Problem[i*K+j]-1]==1)
				||
				(Problem[i*K+j]<0 && vector[-Problem[i*K+j]-1]==-1))
				satisfied=1;

		c+=satisfied;
	}

	return M-c;
}

// Auxiliary function that displays the current assignment of truth values to the propositions.
void display(int *vector){
	int i;
	for(i=0;i<N;i++)
		if(vector[i]==1)
			printf("P%d=true  ",i+1);
		else
			printf("P%d=false  ",i+1);
}


// The gready algorithm
void hill_climbing(char **argv)
{
	FILE *outfile;
	int *vector;
	int i, h, h1, h2;
	clock_t t, t1, t2;
	long restarts=0, steps=0;
	int best_change;

	vector=(int*) malloc(N*sizeof(int));

	t1=clock();

	// Initialization steps
	initialize(vector);
	h=count(vector);

	while (h>0)
	{
		// Check for time limit
		t=clock();
		if (t-t1>CLOCKS_PER_SEC*TIMEOUT)
		{
			t2=clock();
			printf("\n\nNO SOLUTION found with hill-climbing...\n");
			printf("Time spent: %f secs\n",((float) t2-t1)/CLOCKS_PER_SEC);
			printf("Number of restarts: %d\n",restarts);
			printf("Number of steps: %d\n",steps);
			return ;
		}

#ifdef SHOW_COMMENTS
			printf(".");
#endif

		steps++;
		h2=h;
		best_change=-1;
		for(i=0;i<N;i++) {		// For each proposition...
			vector[i]=-vector[i];	// ...if we flip its value...
			h1=count(vector);	// ...how many sentences are not satisfied?
			if (h1<h2)			// If they are less than with previous flips or the current state...
			{
				h2=h1;			// ...remember it!
				best_change=i;
			}
			vector[i]=-vector[i];	// Cancel the last flip of value.
		}

		if (best_change>=0)
			vector[best_change]=-vector[best_change];
		else			// ...else if we had no improvement
		{
			initialize(vector);		// Random restart
			restarts++;
		}
		h=count(vector);
	}

	t2=clock();
	printf("\n\nSolution found with hill-climbing!\n"); display(vector); printf("\n");
	printf("Time spent: %f secs\n",((float) t2-t1)/CLOCKS_PER_SEC);
	printf("Number of restarts: %d\n",restarts);
	printf("Number of steps: %d\n",steps);

	outfile=fopen(argv[3],"w");
	if (outfile==NULL) {
		printf("Cannot open output file. Now exiting...\n");
		return;
	}
	for(i=0;i<N;i++)
		fprintf(outfile,"%d ",vector[i]);
	fclose(outfile);

}

// Auxiliary function that copies the values of one vector to another
void copy(int *vector1, int *vector2) {
	int i;
	for(i=0;i<N;i++)
		vector2[i]=vector1[i];
}


// This function creates a new stack node and pushes it on the top of the stack.
// Memory for the vector of the stack node is allocated.
// Input vector is not altered.
int push(int *vector)
{
	struct stack_item *temp=(struct stack_item*) malloc(sizeof(struct stack_item));
	if (temp==NULL)
		return 0;
	temp->vector=(int*) malloc(N*sizeof(int));
	copy(vector,temp->vector);
	temp->next=head;
	head=temp;
	return 1;
}

// This function retracts the top node of the stack.
// The function returns the vector of this node, while it frees the memory of the 'stack_item' node.
int* pop()
{
	struct stack_item *temp;
	int *vector;
	if (!head)
		return NULL;
	vector=head->vector;
	temp=head;
	head=head->next;
	free(temp);
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

// Given a partial assignment vector, for which a subset of the first propositions have values,
// this function pushes up to two new vectors to the stack, which concern giving to the first unassigned
// proposition the values true=1 and false=-1, after checking that the new vectors are valid.
int generate_children(int *vector)
{
	int i,err;

	for(i=0;i<N && vector[i]!=0;i++);	// Find the first proposition with no assigned value.

	vector[i]=-1;
	if (valid(vector))				// Check whether a "false" assignment is acceptable...
	{
		err=push(vector);			// ...and push to the stack if yes.
		if (err==0)
			return 0;
	}

	vector[i]=1;
	if (valid(vector))				// Check whether a "true" assignment is acceptable...
	{
		err=push(vector);			// ...and push to the stack if yes.
		if (err==0)
			return 0;
	}

	free(vector);					// Since "push" generates new vectors, the current vector can be deleted from memory.
	return 1;
}


// The systematic algorithm.
void depth_first(char **argv)
{
	int steps=0;
	int i;
	clock_t t, t1, t2;

	int *vector=(int*) malloc(N*sizeof(int));
	for(i=0;i<N;i++)
		vector[i]=0;


	t1=clock();
	push(vector);	// Initializing the stack.
	free(vector);	// Since "push" copies the vector, we can delete the previous vector.

	// While the stack is not empty...
	while(head)
	{
		t=clock();		// Check for the time limit
		if (t-t1>CLOCKS_PER_SEC*TIMEOUT)
		{
			t2=t;
			printf("\n\nNO SOLUTION found with depth-first within the time limit...\n");
			printf("Time spent: %f secs\n",((float) t2-t1)/CLOCKS_PER_SEC);
			printf("Number of steps: %d\n",steps);
			return ;
		}

		vector=pop();		// Retract the top element from the stack.
		steps++;
		if (solution(vector))	// If it is a solution...
		{
			FILE *outfile;
			t2=clock();
			printf("\n\nSolution found with depth-first!\n"); display(vector); printf("\n");
			printf("Time spent: %f secs\n",((float) t2-t1)/CLOCKS_PER_SEC);
			printf("Number of steps: %d\n",steps);
			outfile=fopen(argv[3],"w");
			if (outfile==NULL) {
				printf("Cannot open output file. Now exiting...\n");
				return;
			}
			for(i=0;i<N;i++)
				fprintf(outfile,"%d ",vector[i]);
			fclose(outfile);
			return;
		}

		generate_children(vector);	// ...else generate its children.
	}

	// If the stack is empty without any solution found...
	t2=clock();
	printf("\n\nNO SOLUTION EXISTS. Proved by depth-first!\n");
	printf("Time spent: %f secs\n",((float) t2-t1)/CLOCKS_PER_SEC);
	printf("Number of steps: %d\n",steps);
	return ;
}

void syntax_error(char **argv) {
	printf("Use the following syntax:\n\n");
	printf("%s <method> <inputfile> <outputfile>\n\n",argv[0]);
	printf("where:\n");
	printf("<method> is either 'hill' or 'depth' (without the quotes)\n");
	printf("<inputfile> is the name of the file with the problem description\n");
	printf("<outputfile> is the name of the output file with the solution\n");
}

int main(int argc, char **argv) {
	int err;

	srand( (unsigned)time( NULL ) );

	if (argc!=4) {
		printf("Wrong number of arguments. Now exiting...\n");
		syntax_error(argv);
		return -1;
	}

	err=readfile(argv[2]);
	if (err<0)
		return -1;

//	display_problem();

	if (strcmp(argv[1],"hill")==0)
		hill_climbing(argv);
	else if (strcmp(argv[1],"depth")==0)
		depth_first(argv);
	else
		syntax_error(argv);

	return 0;
}
