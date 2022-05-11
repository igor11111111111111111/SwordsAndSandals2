using System;

namespace SwordsAndSandals.Arena
{
    public class EndBattleHandler
    {
        public Action<Info> OnEndBattle;
         
        public EndBattleHandler(AttackHandler playerAttackHandler)
        {
            playerAttackHandler.OnWin += () => OnEndBattle?.Invoke(new Info(false, true));
            playerAttackHandler.OnLose += () => OnEndBattle?.Invoke(new Info(false, false));
            // !!!false tournament
        }

        public class Info
        {
            public readonly bool IsTournament;
            public readonly bool IsWin;

            public Info(bool isTournament, bool isWin)
            {
                IsTournament = isTournament;
                IsWin = isWin;
            }
        }
    }
}
