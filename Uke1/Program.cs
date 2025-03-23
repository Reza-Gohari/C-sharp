using System.Globalization;

int x;
int factorial = 1;
int num;

Console.WriteLine("Skriv ett tall her :");
num = int.Parse(Console.ReadLine());

for(x=1 ; x<= num ;x++);
{
    factorial = factorial*x;
}

Console.Write("Faktoriale av nummer "+ num +": "+ factorial);
