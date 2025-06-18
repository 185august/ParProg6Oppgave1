using System.Text.Json;

namespace ParProg6Oppgave1
{
    public class JsonTest
    {
        string path = Path.Combine(AppContext.BaseDirectory, "insektnew.json");
        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        public void SaveInsekter(List<BaseInsect> insekter)
        {

            string json = JsonSerializer.Serialize(insekter, options);
            File.WriteAllText(path, json);
            Console.WriteLine("Insekter lagret til JSON-fil.");
        }

        public List<BaseInsect> LoadInsekter()
        {
            string json = File.ReadAllText(path);
            var insektListe = JsonSerializer.Deserialize<List<BaseInsect>>(json);
            if (insektListe != null)
            {
                Console.WriteLine("Insekter lastet fra JSON-fil.");
                return insektListe;
            }
            else
            {
                Console.WriteLine("Ingen insekter funnet i JSON-filen.");
                return new List<BaseInsect>();
            }
        }
    }
}
