// See https://aka.ms/new-console-template for more information
using static kodePos;
using static Program;
public enum Kelurahan { Batinunggal, Kujangsari, Mengger, Wates, Cijaura, Jatisari, Margasari, Sekejati, Kebonwaru, Maleer, Samoja }

public class Program
{
    
   
    static void Main(string[] args)
    {
        // Example usage:
        Console.WriteLine("List Kelurahan: ");
        foreach (Kelurahan county in Enum.GetValues(typeof(Kelurahan)))
        {
            int postalCode = getKodePoes(county);
            Console.WriteLine(county +": " + postalCode);
        }
    }
}

public class kodePos
{
    public static int getKodePoes(Kelurahan county)
    {
        int[] postalCode = { 40266, 40287, 40267, 40256, 40287, 40286, 40286, 40286, 40272, 40274, 40273 };
        return postalCode[(int)county];

    }
}
 