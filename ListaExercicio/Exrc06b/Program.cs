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

Array.Sort(numeros);

Console.WriteLine("");
Console.WriteLine("");
for (int i = 0; i < 100; i++)
{
    Console.Write(numeros[i] + " ");
}