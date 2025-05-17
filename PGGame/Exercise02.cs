namespace PGGame;

public static class Exercise02
{
    private static Random r = new Random();
    private static bool truth= false;
    private static bool shuffleOn = false;
    
    public static void DisplayShop()
    {
        Console.Clear();
        Console.Title = "Variable Shop";
        Console.WriteLine();
        Console.WriteLine("ᶘ ᵒᴥᵒᶅ");
        Console.WriteLine();
        Console.WriteLine("See my wares! I have lots of variables!");
        Console.WriteLine($"{"[S] - shuffle", -10}{"[E] - exit", -10}");

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0,5);
            string input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            
            if (input.ToUpper() == "S")
            {
                shuffleOn = !shuffleOn;
                DisplayWares();
            }
            
            else if (input.ToUpper() == "E")
            {
                break;
            }
            
        }
        //Console.ReadKey();
    }

    private static void DisplayWares()
    {
        Console.SetCursorPosition(0,5);
        Console.WriteLine($"Floating numbers:");
        Console.WriteLine($"|{"Float",-10}|{(shuffleOn? sbyte.MinValue : sbyte.MaxValue),-30}|");
        Console.WriteLine($"|{"Double",-10}|{(shuffleOn? double.MinValue : double.MaxValue),-30}|");
        Console.WriteLine($"|{"Decimal",-10}|{(shuffleOn? decimal.MinValue : decimal.MaxValue),-30}|");
        Console.WriteLine($"\nSigned numbers:");
        Console.WriteLine($"|{"SByte",-10}|{(shuffleOn? sbyte.MinValue : sbyte.MaxValue),-30}|");
        Console.WriteLine($"|{"Short",-10}|{(shuffleOn? short.MinValue : short.MaxValue),-30}|");
        Console.WriteLine($"|{"Int",-10}|{(shuffleOn? int.MinValue : int.MaxValue),-30}|");
        Console.WriteLine($"|{"Long",-10}|{(shuffleOn? long.MinValue : long.MaxValue),-30}|");
        Console.WriteLine($"\nUnsigned numbers:");
        Console.WriteLine($"|{"Byte",-10}|{(shuffleOn? byte.MinValue : byte.MaxValue),-30}|");
        Console.WriteLine($"|{"UShort",-10}|{(shuffleOn? ushort.MinValue : ushort.MaxValue),-30}|");
        Console.WriteLine($"|{"UInt",-10}|{(shuffleOn? uint.MinValue : uint.MaxValue),-30}|");
        Console.WriteLine($"|{"ULong",-10}|{(shuffleOn? ulong.MinValue : ulong.MaxValue),-30}|");
        Console.WriteLine($"\nMisc:");
        Console.WriteLine($"|{"String",-10}|{(shuffleOn? "bli" : "blubb"),-30}|");
        Console.WriteLine($"|{"Char",-10}|{PickRandomChar(),-30}|");
        Console.WriteLine($"|{"Bool",-10}|{(shuffleOn? truth : !truth),-30}|");
    }
    
    private static char PickRandomChar()
    {
        string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
        char[] charsToPickFrom = chars.ToCharArray();
        Random r = new Random();
        return charsToPickFrom[r.Next(0, chars.Length)];
    }
}