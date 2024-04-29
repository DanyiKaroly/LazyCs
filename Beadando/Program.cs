using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Threading;
using System.Threading.Channels;

namespace Beadando
{
    class Program
    {
        public static EventWaitHandle waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);

        static void Main(string[] args)
        {

            Thread thread = new Thread(DoWork);
            thread.Start();
            Thread.Sleep(1000);
            LazyCollection example = new LazyCollection();
            int kilepo = 0;
            int feladat = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("üdvözlöm a programban!");
                Console.WriteLine("Nyomja meg a 0-at a kilépéshez");
                Console.WriteLine("Nyomja meg az 1-est a töltésre.");
                Console.WriteLine("Nyomja meg a 2-est a lazy ellenörzésére.");
                Console.WriteLine("Nyomja meg a 3-ast a lazy felébresztésére.");
                Console.WriteLine("Nyomja meg a 4-est a lazy kiiratására.");
                Console.WriteLine("Nyomja meg az 5-öst hogy hozzá adj a listához 1-et."); 
                Console.WriteLine("Nyomja meg az 6-ost a listához adáshoz.");
                Console.WriteLine("Nyomja meg a 7-est ha le szeretné ellenőrizni hogy a lazy tartalmazza-e az adatot.");
                Console.WriteLine("Nyomja meg a 8-ast az elemek összeadásához.");
                Console.WriteLine("Nyomja meg a 9-est az első elem törléséhez.");
                Console.WriteLine("Írja be a 10-est az első elem törléséhez.");
                Console.WriteLine("Írja be a 11-est a sorba rendezéshez.");
                Console.WriteLine("Írja be a 12-est ha szeretné tudni hány elemet tartalmaz a lista.");

                feladat = Convert.ToInt32(Console.ReadLine());
                switch (feladat)
                {
                    case 1:
                        example.Loading();
                        break;

                    case 2:
                        if(example.IsOkay())
                        {
                            Console.Clear();
                            Console.WriteLine("Létre jött!");
                        }
                        else {
                        Console.Clear();
                        Console.WriteLine("Nem jött létre!");
                        }
                        break;
                    case 3:
                        example.YouAreFinallyAwake();
                        Console.Clear();
                        Console.WriteLine("Felébresztés megtörtént!");
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Lazy adatai:");
                        example.LazyKiiratas();
                        break;
                    case 5:
                        example.AddMoreLazy();
                        Console.Clear();
                        Console.WriteLine("Sikeres hozzáadás!");
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Adjon meg egy számot!");
                        example.LazyAddInput(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Adjon meg egy számot!");
                        if (example.ContainsElement(Convert.ToInt32(Console.ReadLine())))
                        {
                            Console.WriteLine("Tartalmazza!");
                        }
                        else Console.WriteLine("Nem tartalmazza");

                        break;

                    case 8:
                        Console.Clear();
                        Console.WriteLine("Az adatok összege:");
                        Console.WriteLine(example.SumOfElements());
                        break;

                    case 9:
                        Console.Clear();
                        example.RemoveFirstElement();
                        break;
                    case 10:
                        Console.Clear();
                        example.RemoveFirstElement();
                        break;

                    case 11:
                        Console.Clear();
                        example.SortList();
                        break;
                    case 12:
                        Console.Clear();
                        Console.WriteLine(example.ListCount());
                        break;
                    case 13:
                        Console.Clear();
                        break;
                    default:
                        kilepo = 1;
                        break;
                        

                }
                if(kilepo==0)
                {
                    Console.WriteLine("Press enter to continue!");
                    Console.ReadKey();
                }

            } while (feladat != 0);

            Console.WriteLine("Kilépés a programból");
            waitHandle.Set();
            thread.Join();

        }
        static void DoWork()
        {
            waitHandle.WaitOne();
            Console.Clear();
            Console.Write("Loading");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
        }
    }
}