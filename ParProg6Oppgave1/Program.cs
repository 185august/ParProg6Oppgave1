
namespace AugustMichal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            BaseIsect isekt = new BaseIsect("Michal", true, true, "something here", 2, "går");
            isekt.ShowInfo();
        }
        public class BaseIsect
        {
            public BaseIsect(string name, bool kanFly, bool kanBite, string plage, int harBeina, string bevegeseMote)
            {
                Name = name;
                KanFly = kanFly;
                KanBite = kanBite;
                Plage = plage;
                HarBeina = harBeina;
                BevegeseMote = bevegeseMote;
            }

            public string Name { get; }
            public bool KanFly { get; set; }
            public bool KanBite { get; set; }

            public string Plage { get; set; }
            public int HarBeina { get; set; }
            public string BevegeseMote { get; set; }


            public void ShowInfo()
            {
                Console.Write("Info om insekt");
                Console.WriteLine($" Insetk navn: {Name}");
                Console.WriteLine($" Kan Fly: {KanFly}");
                Console.WriteLine($" Kan bite: {KanBite}");
                Console.WriteLine($" Plage: {Plage}");
                Console.WriteLine($" Antall bein: {HarBeina}");
                Console.WriteLine($" Beskriv bevegelsesmote: {BevegeseMote}");
            }



        }

        public class Mygg : BaseIsect
        {
            public Mygg(string name, bool kanFly, bool kanBite, string plage, int harBeina, string bevegeseMote) : base(name, kanFly, kanBite, plage, harBeina, bevegeseMote)


        }



        //public class Mygg : BaseIsect
        //{
        //    public Mygg(string name, bool kanFly, bool kanBite, string plage, int harBeina, string bevegeseMote) : base(name, kanFly, kanBite, plage, harBeina, bevegeseMote)
        //    {

        //    }
        //}

    }
}


