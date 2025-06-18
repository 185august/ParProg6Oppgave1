namespace ParProg6Oppgave1
{
    public class Edderkopp : BaseInsect
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
}
