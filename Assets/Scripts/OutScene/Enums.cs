namespace SwordsAndSandals
{
    public class Enums
    {
        public enum Direction
        {
            Right,
            Left,
            None
        }

        public enum CurrentState
        {
            Sleep,
            Punch,
            Rage,
            Move,
            Jump,
            Dance,
            Charge,
            WeakAttack,
            MediumAttack,
            HardAttack,
            SuperAttack1,
            SuperAttack2,
            SuperAttack3
        }

        public enum AttackType
        {
            Charge = 0,
            WeakAttack = 1,
            MediumAttack = 2,
            HardAttack = 3
        }

        public enum SuperAttackState
        {
            SuperAttack1 = 0,
            SuperAttack2 = 1,
            SuperAttack3 = 2
        }

        public enum SaveFilename
        {
            Player,
            Settings,
            Tournament
        }

        public enum Scene
        {
            Street,
            PreArena,
            Arena,
            Editor,
            Menu,
            LevelUp,
            ArmorShop,
            WeaponShop,
            Tournament
        }

        public enum Team
        {
            Player,
            AI
        }
    }
}
