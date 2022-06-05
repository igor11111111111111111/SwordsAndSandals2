namespace SwordsAndSandals
{
    public class Price
    {
        public int Original => _original;
        private int _original;
        public int CharismaPercentDiscount => _charismaPercentDiscount;
        private int _charismaPercentDiscount;
        public int CharismaDiscount => _charismaDiscount;
        private int _charismaDiscount;
        public int TradeInDiscount => _tradeInDiscount;
        private int _tradeInDiscount;
        public int Final => _final;
        private int _final;

        public Price(int original, int charismaDiscount, int tradeInDiscount)
        {
            _original = original;
            _charismaPercentDiscount = charismaDiscount;
            _tradeInDiscount = tradeInDiscount;
            _charismaDiscount = (int)(original * charismaDiscount / 100f);
            _final = Original - CharismaDiscount - TradeInDiscount;
        } 
    }
}

