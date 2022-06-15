using System;

namespace SwordsAndSandals.Arena
{
    public interface IUseInput
    {
        public Action[] Actions { get; set; }
        public Action<bool> OnInBattle { get; set; }
    }
}