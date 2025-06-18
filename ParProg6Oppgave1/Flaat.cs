namespace ParProg6Oppgave1
{
    public class Flaatt : BaseInsect
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
}
