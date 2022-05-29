namespace SwordsAndSandals
{
    public class Reward
    {
        public readonly int XP;
        public readonly int Money;

        public Reward(int xp, int money)
        {
            XP = xp;
            Money = money;
        }

        public Reward()
        {
            XP = 0;
            Money = 0;
        }
    }
}
 