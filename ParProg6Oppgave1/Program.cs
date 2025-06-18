using ParProg6Oppgave1;

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
            List<BaseInsect> insekter = new List<BaseInsect>
            {
                new Mygg(),
                new Husflue(),
                new Edderkopp(),
                new Flaatt(),
                new Veps()
            };
            //List<BaseInsect> insekter = json.LoadInsekter();


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

                        var nyttInsekt = new BaseInsect(name, kanFly, kanBite, plage, harBeina, bevegelse);
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














}