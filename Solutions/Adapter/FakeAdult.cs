namespace Adapter
{
    internal class FakeAdult : Adult
    {
        private Teenager teenager;

        public FakeAdult(string name, int age) : base(name, age)
        {
            teenager = new Teenager(name, age);
        }

        public override bool checkIsAdult()
        {
            return true;
        }

        // When partying, delegate to Teenager's behavior
        public override void letsParty()
        {
            teenager.letsParty();
        }
    }
}
