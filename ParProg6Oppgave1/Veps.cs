namespace ParProg6Oppgave1
{
    public class Veps : BaseInsect
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
}
