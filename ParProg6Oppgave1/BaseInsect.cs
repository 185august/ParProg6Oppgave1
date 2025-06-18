namespace ParProg6Oppgave1
{
    public class BaseInsect
    {
        public BaseInsect(string name, bool kanFly, bool kanBite, string plage, int harBeina, string bevegelseMaate)
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
}
