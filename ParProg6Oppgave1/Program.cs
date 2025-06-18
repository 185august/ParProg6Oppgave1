using System.Text.Json;

namespace Insekt
{
    internal class Program
    {
        enum MenuValg
        {
            SeListe = 1,
            LeggTil = 2,
            Avslutt = 3,
            Fjern = 4,
            Ugyldig = 0
        }

        static void Main(string[] args)
        {
            JsonTest json = new();
            List<BaseIsect> insekter = new List<BaseIsect>
            {
                new Mygg(),
                new Husflue(),
                new Edderkopp(),
                new Flaatt(),
                new Veps()
            };
            json.SaveInsekter(insekter);

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n    InsektOppslagsverket    ");
                Console.WriteLine("1. Se liste over insekter");
                Console.WriteLine("2. Legg inn nytt insekt");
                Console.WriteLine("3. Avslutt");
                Console.WriteLine("4. Fjern insekt");
                Console.Write("Ditt valg: ");
                string valg = Console.ReadLine();

                MenuValg menuValg = MenuValg.Ugyldig;
                if (int.TryParse(valg, out int valgInt) && Enum.IsDefined(typeof(MenuValg), valgInt))
                {
                    menuValg = (MenuValg)valgInt;
                }

                switch (menuValg)
                {
                    case MenuValg.SeListe:
                        for (int i = 0; i < insekter.Count; i++)
                            Console.WriteLine($"{i}: {insekter[i].Name}");

                        Console.Write("Skriv nummeret for å se mer: ");
                        if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 0 && idx < insekter.Count)
                        {
                            insekter[idx].ShowInfo();
                        }
                        break;

                    case MenuValg.LeggTil:
                        Console.Write("Navn: ");
                        string name = Console.ReadLine();

                        Console.Write("Kan fly (true/false): ");
                        bool.TryParse(Console.ReadLine(), out bool kanFly);

                        Console.Write("Kan bite (true/false): ");
                        bool.TryParse(Console.ReadLine(), out bool kanBite);

                        Console.Write("Plage: ");
                        string plage = Console.ReadLine();

                        Console.Write("Antall bein: ");
                        int.TryParse(Console.ReadLine(), out int harBeina);

                        Console.Write("Bevegelsesmåte: ");
                        string bevegelse = Console.ReadLine();

                        var nyttInsekt = new BaseIsect(name, kanFly, kanBite, plage, harBeina, bevegelse);
                        insekter.Add(nyttInsekt);
                        Console.WriteLine("Insekt lagt til!");
                        json.SaveInsekter(insekter);
                        break;

                    case MenuValg.Avslutt:
                        Console.WriteLine("Avslutter...");
                        running = false;
                        break;

                    case MenuValg.Fjern:
                        for (int i = 0; i < insekter.Count; i++)
                            Console.WriteLine($"{i}: {insekter[i].Name}");

                        Console.Write("Skriv nummeret på insektet du vil fjerne: ");
                        if (int.TryParse(Console.ReadLine(), out int fjernIdx) && fjernIdx >= 0 && fjernIdx < insekter.Count)
                        {
                            Console.WriteLine($"Fjerner: {insekter[fjernIdx].Name}");
                            insekter.RemoveAt(fjernIdx);
                        }
                        else
                        {
                            Console.WriteLine("Ugyldig nummer.");
                        }
                        break;

                    default:
                        Console.WriteLine("Ugyldig valg.");
                        break;
                }
            }
        }
    }

    public class BaseIsect
    {
        public BaseIsect(string name, bool kanFly, bool kanBite, string plage, int harBeina, string bevegelseMaate)
        {
            Name = name;
            KanFly = kanFly;
            KanBite = kanBite;
            Plage = plage;
            HarBeina = harBeina;
            BevegelseMaate = bevegelseMaate;
        }

        public string Name { get; set; }
        public bool KanFly { get; set; }
        public bool KanBite { get; set; }
        public string Plage { get; set; }
        public int HarBeina { get; set; }
        public string BevegelseMaate { get; set; }

        public virtual void ShowInfo()
        {
            Console.WriteLine("Info om insekt");
            Console.WriteLine($" Insekt navn: {Name}");
            Console.WriteLine($" Kan Fly: {KanFly}");
            Console.WriteLine($" Kan bite: {KanBite}");
            Console.WriteLine($" Plage: {Plage}");
            Console.WriteLine($" Antall bein: {HarBeina}");
            Console.WriteLine($" Beskriv bevegelsesmåte: {BevegelseMaate}");
            Console.WriteLine("Spesiel funksjon ");
        }
    }

    public class Mygg : BaseIsect
    {
        public Mygg() : base("Mygg", true, true, "Suger blod, gir kløe", 6, "Flyr") { }

        public void Fly()
        {
            Console.Write("Myggen flyr av gårde");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Fly();
        }
    }

    public class Husflue : BaseIsect
    {
        public Husflue() : base("Husflue", true, false, "Irriterende, lander på mat", 6, "Flyr") { }

        public void MakeBzzzzSound()
        {
            Console.Write("BzzzzzzzzzzzzzzBzzzzzzzzzzzzBzzzzzzzzzzz");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            MakeBzzzzSound();
        }
    }

    public class Edderkopp : BaseIsect
    {
        public Edderkopp() : base("Edderkopp", false, true, "Kan skremme folk", 8, "Går") { }

        public void MakeWeb()
        {
            Console.Write("Edderkoppen starter å spinne et web");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            MakeWeb();
        }
    }

    public class Flaatt : BaseIsect
    {
        public Flaatt() : base("Flaatt", false, true, "Kan spre sykdom", 8, "Kryper") { }

        public void SuckBlood()
        {
            Console.Write("Flaatten suger blod fra sitt offer");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            SuckBlood();
        }
    }

    public class Veps : BaseIsect
    {
        public Veps() : base("Veps", true, true, "Stikker smertefullt", 6, "Flyr") { }

        public void Attack()
        {
            Console.Write("Vepsen stikker deg");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Attack();
        }
    }

    public class JsonTest
    {
        string path = Path.Combine(AppContext.BaseDirectory, "insektnew.json");
        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        public void SaveInsekter(List<BaseIsect> insekter)
        {

            string json = JsonSerializer.Serialize(insekter, options);
            File.WriteAllText(path, json);
            Console.WriteLine("Insekter lagret til JSON-fil.");
        }

        public void LoadInsekter()
        {
            string json = File.ReadAllText(path);
        }
    }
}