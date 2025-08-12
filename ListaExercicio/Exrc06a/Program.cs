//passos para resolver o bubble sort 
//1 - criar um vetor (array) para receber 100 posições
//2 - criar um laço de repetição para percorrer o vetor 
//3 - preencher cada posição com um valor aleatório 
//4 - imprimir o vetor com valores aleatórios 


int[] numeros = new int[100];

Random aleatorio = new Random();


for (int i = 0; i < 100; i++)
{
    numeros[i] = aleatorio.Next(1,101);
}

for (int i = 0; i < 100; i++)
{
    Console.Write(numeros[i] + " ");
}

//5 - percorrer o vetor com valores aleatórios
//6 - comparar a posição atual com a próxima
//7 - se a proxima for menor que a atual elas trocam de posição 
//8 - imprimir o vetor com valores ordenados 

bool troca = false;
do
{
    troca = false;
    
    for (int i = 0; i < 100 - 1; i++)
    {
        int posicaoAtual = numeros[i];
        int proxima = numeros[i + 1];
        int trocador = 0;

        if (proxima < posicaoAtual)
        {
            troca = true;
            trocador = proxima;
            numeros[i + 1] = numeros[i];
            numeros[i] = trocador;
        }
    }

} while (troca == true);

Console.WriteLine("");
Console.WriteLine("");
for (int i = 0; i < 100; i++)
{
    Console.Write(numeros[i] + " ");
}

//9 - fazer ate todos os numeros do vetor estiverem ordenados

