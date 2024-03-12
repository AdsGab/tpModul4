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
        Pintu objPintu = new Pintu();
        Console.WriteLine(objPintu.currentState);
        objPintu.ActivateTrigger(Trigger.KunciPintu);
        Console.WriteLine(objPintu.currentState);
        objPintu.ActivateTrigger(Trigger.bukaPintu);
        Console.WriteLine(objPintu.currentState);
        

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
 
public  enum pintuState { TERKUNCI, TERBUKA};
public enum Trigger {bukaPintu, KunciPintu};
public class Pintu
{
    public class DoorMachine
    {
        public pintuState stateAwal;
        public pintuState stateAkhir;
        public Trigger trigger;

        public DoorMachine(pintuState stateAwal, pintuState stateAkhir, Trigger trigger)
        {
            this.stateAwal = stateAwal;
            this.stateAkhir = stateAkhir;
            this.trigger = trigger;
        }

    }
        DoorMachine[] transisi =
        {
        new DoorMachine(pintuState.TERBUKA, pintuState.TERKUNCI, Trigger.KunciPintu),
        new DoorMachine(pintuState.TERKUNCI, pintuState.TERBUKA, Trigger.bukaPintu),
         };

        public pintuState currentState = pintuState.TERKUNCI;

        public pintuState GetNextState(pintuState stateAwal, Trigger trigger)
        {
            pintuState stateAkhir = stateAwal;
            for (int i = 0; i < transisi.Length; i++)
            {
                DoorMachine perubahan = transisi[i];
                if (stateAwal == perubahan.stateAwal && trigger == perubahan.trigger)
                {
                    stateAkhir = perubahan.stateAkhir;
                }
            }
            return stateAkhir;
        }

        public void ActivateTrigger(Trigger trigger)
        {
            currentState = GetNextState(currentState, trigger);
            Console.WriteLine("State anda Sekarang adalah : " + currentState);
            if (currentState == pintuState.TERBUKA)
            {
                Console.WriteLine("Pintu tidak Terkunci");
            } else if(currentState == pintuState.TERKUNCI) {
            Console.WriteLine("Pintu Terkkunci");
        }
        }
    }
