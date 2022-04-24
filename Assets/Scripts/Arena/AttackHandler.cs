using UnityEngine;
using System;

namespace SwordsAndSandals.Arena
{
    public class AttackHandler
    {
        public Action OnBlock;
        public Action OnLose;
        private PlayerInjector _player;
        private PlayerInjector _enemy;
        private PlayerData _playerArenaData;
        private ArenaHandler _arenaHandler;
        private DamageInfo _damageInfo;

        public AttackHandler(PlayerData playerArenaData, PlayerInjector player, PlayerInjector enemy, ArenaHandler arenaHandler, DamageInfo damageInfo)
        {
            _player = player;
            _enemy = enemy;
            _playerArenaData = playerArenaData;
            _arenaHandler = arenaHandler;
            _damageInfo = damageInfo;

            _player.Controller.OnAttack += Attack;
            _player.Controller.OnTakeDamage += TakeDamage;
        }

        private void Attack(Enums.AttackType attackType)
        {
            _enemy.Controller.OnTakeDamage?.Invoke(attackType);
        }

        private void TakeDamage(Enums.AttackType attackType)
        {
            var enemyAttackChance = _enemy.Data.DataSkills.Get<Attack>().GetHitChance(attackType);
            var playerDefenceChance = _player.Data.DataSkills.Get<Defence>().GetDodgeChance(attackType);
            var totalChance = Mathf.Clamp(enemyAttackChance - playerDefenceChance, 1, 99);
            var randomChance = UnityEngine.Random.Range(0, 101);

            if (randomChance <= totalChance)
            {
                var damage = _enemy.Data.DataWeapons.Current.Damage;
                float attackCoeff = 0;

                if (attackType == Enums.AttackType.Charge && Mathf.Abs(_arenaHandler.GetDistance()) > 3.5f)
                    return;

                if (attackType == Enums.AttackType.Charge)
                {
                    attackCoeff = 0.7f;
                }
                else if (attackType == Enums.AttackType.WeakAttack)
                {
                    attackCoeff = 0.5f;
                }
                else if (attackType == Enums.AttackType.MediumAttack)
                {
                    attackCoeff = 1f;
                }
                else if (attackType == Enums.AttackType.HardAttack)
                {
                    attackCoeff = 1.5f;
                }

                damage = Mathf.RoundToInt(damage * attackCoeff);

                if (_playerArenaData.ArmorData.Current <= damage)
                {
                    damage -= _playerArenaData.ArmorData.Current;
                    _playerArenaData.ArmorData.Current = 0;
                    _playerArenaData.HealthData.Current -= damage;
                }
                else
                {
                    _playerArenaData.ArmorData.Current -= damage;
                }

                if(_playerArenaData.HealthData.Current == 0)
                {
                    OnLose?.Invoke();
                }
                
                _player.ClothChanger.Drop(_player.Data.DataArmors);

                _damageInfo.Show(damage, _player);
            }
            else
            {
                OnBlock?.Invoke();
                _damageInfo.Show(0, _player);
            }
        }
    }
}
