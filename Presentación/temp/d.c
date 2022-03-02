#include <stdio.h>
#include <conio.h>
#include <math.h>

/*********** VARIABLES GLOBALES **********************/

/*float matriz[50][50];
float identidad[50][50];
int N; //N contiene el tamañoo de la matriz cuadrada*/

/*********** PROTOTIPOS DE FUNCIONES *****************/

void inversa(float matriz[][50], float identidad[][50], int N); //main
void multiFila(int fila,double factor, float matriz[][50], float identidad[][50], int N);
void cerosAb(int filaPivot, int columPivot, float matriz[][50], float identidad[][50], int N);
void cerosAr(int filaPivot, int columPivot, float matriz[][50], float identidad[][50], int N);
void sumFila(int fila1,int fila2, double factor, float matriz[][50], float identidad[][50], int N);
/*void escalonar_matriz(void);
void permutar_filas(int fila1, int fila2);
void sumar_fila_multip(int fila1,int fila2, double factor);
void generar_matriz_identidad(void);*/

/*****************************************************/
 
int main()
{
int fi, co;
float matriz[50][50];
float identidad[50][50];
int N;
do{
printf("Ingrese el tamano de la matriz cuadrada: ");
scanf("%d",&N);
if(N>50 || N<2) {printf("El numero debe estar entre 2 y 50n");}
}while(N>50 || N<2);

for(fi=0;fi<N;fi++)
{
for(co=0;co<N;co++)
{
printf("Ingrese el valor de matriz[%i][%i]",fi+1,co+1);
scanf("%f",&matriz[fi][co]);
}
}

inversa(matriz,identidad,N);

return 0;
}

/*-------------------------------------------------------------------------*/

void inversa(float matriz[][50], float identidad[][50], int N)
{
int cont2, flag=0;
float auxval;
int cont, col, ceros, vec[10], aux,i,j;


for(cont=0;cont<N;cont++)
{
col=0,ceros=0;

if(matriz[cont][col]==0)
{
do{
ceros++;
col++;
}while(matriz[cont][col]==0);
}
vec[cont]=ceros;
}

do
{
flag=0;
for(cont=0;cont<N-1;cont++)
{
if(vec[cont]>vec[cont+1])
{
aux=vec[cont];
vec[cont]=vec[cont+1];
vec[cont+1]=aux;


for(cont=0;cont<N;cont++)
{
auxval=matriz[cont][cont];
matriz[cont][cont]=matriz[cont+1][cont];
matriz[cont+1][cont]=auxval;

auxval=identidad[cont][cont];
identidad[cont][cont]=identidad[cont+1][cont];
identidad[cont+1][cont]=auxval;
}

flag=1;
}
}
}while(flag==1);

for(i=0;i<50;i++)
{
for(j=0;j<50;j++)
{
if(i==j) identidad[i][j]=1;
else identidad[i][j]=0;
}
} //rellena la matriz identidad

for(cont=0;cont<N;cont++) //recorre filas
{
for(cont2=0;cont2<N;cont2++) //recorre columnas
{
if(matriz[cont][cont2]!=0) //busca pivote (elemento ditinto de 0)
{
if(matriz[cont][cont2]!=1) //si pivote no es 1, se lo multiplica
{
multiFila(cont,pow(matriz[cont][cont2],-1),matriz, identidad, N);
}

cerosAr(cont,cont2, matriz, identidad, N); // se hacen 0's por arriba
cerosAb(cont,cont2, matriz, identidad, N); // y por debajo del pivot

break;
}
}
}

/*--------------------------------------------------------------*/
/* Una vez terminada esta operacion, la matriz identidad estara */
/* transformada en la inversa */
/* */
/* Ahora se comprueba que la matriz original este transformada */
/* en la matriz identidad, de no ser asi la inversa obtenida */
/* no es valida y la matriz no tiena inversa */
/*--------------------------------------------------------------*/

for(cont=0;cont<N;cont++)
{
for(cont2=0;cont2<N;cont2++)
{
if(cont==cont2)
{
if(matriz[cont][cont2]!=1) flag=1;
}
else
{
if(matriz[cont][cont2]!=0) flag=1;
}
}
}


if(flag==1)
{
printf("\n\nLa matriz no tiene inversa\n\n");
}
else
{
printf("\n\nLa Matriz Inversa es :\n\n");

for(cont=0;cont<N;cont++)
{
for(cont2=0;cont2<N;cont2++)
{
printf("%0.3f ",identidad[cont][cont2]);

}
printf("\n");
}
}
}

/*-----------------------------------------------------------------------*/
/* */
/* Ordena la matriz de forma que quede en su forma escalonada por */
/* renglones */
/* */
/*-----------------------------------------------------------------------*/

/*void escalonar_matriz(void)
{
int cont, col, ceros, vec[10];
int flag, aux;

for(cont=0;cont<N;cont++)
{
col=0,ceros=0;

if(