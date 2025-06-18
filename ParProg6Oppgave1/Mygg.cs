namespace ParProg6Oppgave1
{
    public class Mygg : BaseInsect
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
}
