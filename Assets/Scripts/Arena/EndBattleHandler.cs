using System;

namespace SwordsAndSandals.Arena
{
    public class EndBattleHandler
    {
        public Action<Info> OnEndBattle;
         
        public EndBattleHandler()
        {

        }

        public void Init(AttackHandler playerAttackHandler)
        {
            // !!!false tournament
            playerAttackHandler.OnWin += () => OnEndBattle?.Invoke(new Info(false, true));
            playerAttackHandler.OnLose += () => OnEndBattle?.Invoke(new Info(false, false));
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
