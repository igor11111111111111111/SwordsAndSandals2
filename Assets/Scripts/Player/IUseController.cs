using System;

namespace SwordsAndSandals
{
    public interface IUseController
    {
        public Action<Enums.CurrentState> OnStartAction { get; set; }
    }
}
