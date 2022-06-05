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
            playerAttackHandler.OnWin += () => OnEndBattle?.Invoke(new Info(Enums.Team.Player));
            playerAttackHandler.OnLose += () => OnEndBattle?.Invoke(new Info(Enums.Team.AI));
        }

        public class Info
        {
            public Enums.Team WinningTeam;

            public Info(Enums.Team winningTeam)
            {
                WinningTeam = winningTeam;
            }
        }
    }
}
