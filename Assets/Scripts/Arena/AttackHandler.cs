using UnityEngine;
using System;
using System.Collections.Generic;

namespace SwordsAndSandals.Arena
{
    public class AttackHandler
    {
        public Action<int, Vector3> OnTakeDamage;
        public Action<int, Vector3> OnBlock;
        public Action OnWin;
        public Action OnLose;

        private PlayerInjector _player;
        private PlayerInjector _enemy;
        private PlayerData _playerArenaData;
        private ArenaHandler _arenaHandler;

        private Dictionary<Enums.AttackType, float> _attackCoeff = 
            new Dictionary<Enums.AttackType, float>
        {
            { Enums.AttackType.Charge, 0.7f },
            { Enums.AttackType.WeakAttack, 0.5f },
            { Enums.AttackType.MediumAttack, 1f },
            { Enums.AttackType.HardAttack, 1.5f },
        };

        public AttackHandler(PlayerData playerArenaData, PlayerInjector player, PlayerInjector enemy, ArenaHandler arenaHandler)
        {
            _player = player;
            _enemy = enemy;
            _playerArenaData = playerArenaData;
            _arenaHandler = arenaHandler;

            _player.Controller.OnAttack += Attack;
            _player.Controller.OnTakeDamage += TakeDamage;
        }

        public void InitEnemyAttackHandler(AttackHandler enemyAttackHandler)
        {
            enemyAttackHandler.OnLose += () => OnWin?.Invoke();
        }

        public void Test()
        { 
            OnLose?.Invoke();
        }

        private void Attack(Enums.AttackType attackType)
        {
            _enemy.Controller.OnTakeDamage?.Invoke(attackType);
        }

        private void TakeDamage(Enums.AttackType attackType)
        {
            if (attackType == Enums.AttackType.Charge && Mathf.Abs(_arenaHandler.GetDistance()) > 3.5f)
                return;

            if (Hit(attackType))
            {
                var weaponDamage = _enemy.Data.DataWeapons.Current.Damage;
                var fullDamage = Mathf.RoundToInt(weaponDamage * _attackCoeff[attackType]);
                 
                if (_playerArenaData.ArmorData.Current <= fullDamage)
                {
                    fullDamage -= _playerArenaData.ArmorData.Current;
                    _playerArenaData.ArmorData.Current = 0;
                    _playerArenaData.HealthData.Current -= fullDamage;
                }
                else
                {
                    _playerArenaData.ArmorData.Current -= fullDamage;
                }

                if(_playerArenaData.HealthData.Current == 0)
                {
                    OnLose?.Invoke();
                    return; 
                }

                OnTakeDamage?.Invoke(fullDamage, _player.transform.position);
            }
            else
            {
                OnBlock?.Invoke(0, _player.transform.position);
            }
        }

        private bool Hit(Enums.AttackType attackType)
        {
            var enemyAttackChance = _enemy.Data.DataSkills.Get<Attack>().GetHitChance(attackType);
            var playerDefenceChance = _player.Data.DataSkills.Get<Defence>().GetDodgeChance(attackType);
            var totalChance = Mathf.Clamp(enemyAttackChance - playerDefenceChance, 1, 99);
            var randomChance = UnityEngine.Random.Range(0, 101);

            return randomChance <= totalChance;
        }
    }
}
