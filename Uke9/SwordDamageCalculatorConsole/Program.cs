// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        SwordDamage swordDamage = new SwordDamage();
        while (true)
        {
            Console.Write("0 for no magic/flaming, 1 for magic, 2 for flaming, 3 for both, anything else to quit: ");
            char key = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (key != '0' && key != '1' && key != '2' && key != '3')
                break;

            // Rull 3d6:
            int roll = RollDice();
            swordDamage.Roll = roll;
            swordDamage.SetMagic(key == '1' || key == '3');
            swordDamage.SetFlaming(key == '2' || key == '3');
            Console.WriteLine($"Rolled {roll} for {swordDamage.Damage} HP\n");
        }
    }

    static int RollDice()
    {
        Random rand = new Random();
        return rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
    }
}
