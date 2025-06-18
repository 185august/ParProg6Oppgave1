namespace ParProg6Oppgave1
{
    public class Husflue : BaseInsect
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
}
