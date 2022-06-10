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

        private Dictionary<Enums.AttackType, float> _attackTypeCoeff = 
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

            InitWeaponFromSaveData();

            _player.Controller.OnAttack += (attackType) => // fix later
            {
                _enemy.Controller.OnTakeDamage?.Invoke(attackType);
            };//
            _player.Controller.OnTakeDamage += TakeDamage;
        }
         
        public void Init(AttackHandler enemyAttackHandler)
        {
            enemyAttackHandler.OnLose += () => OnWin?.Invoke();
        }

        public void Test()
        { 
            OnLose?.Invoke();
        }

        private void InitWeaponFromSaveData()
        {
            _player.Data.DataWeapons.Current = new AllWeaponData().Get(_player.Data.DataWeapons.Current);
        }

        private void TakeDamage(Enums.AttackType attackType)
        {
            if (attackType == Enums.AttackType.Charge && Mathf.Abs(_arenaHandler.GetDistance()) > 3.5f)
                return;

            if (CanHit(attackType))
            {
                Attack(attackType);
            }
            else
            {
                OnBlock?.Invoke(0, _player.transform.position);
            }
        }

        private void Attack(Enums.AttackType attackType)
        {
            var damage = GetDamage(attackType);

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

            if (_playerArenaData.HealthData.Current == 0)
            {
                OnLose?.Invoke();
                return;
            }

            OnTakeDamage?.Invoke(damage, _player.transform.position);
        }

        private int GetDamage(Enums.AttackType attackType)
        {
            int fullDamage = 0;

            if (attackType == Enums.AttackType.Yell)
            {
                fullDamage = _enemy.Data.DataSkills.Get<Charisma>().GetDamage();
            }
            else
            {
                var weaponDamage = _enemy.Data.DataWeapons.Current.GetRandMinMaxDamage();

                fullDamage = Mathf.RoundToInt(weaponDamage * _attackTypeCoeff[attackType] * _enemy.Data.DataSkills.Get<Strength>().DamageCoeff);
            }

            return fullDamage;
        }

        private bool CanHit(Enums.AttackType attackType)
        {
            int enemyAttackChance = 0;
            int playerDefenceChance = 0;

            if (attackType == Enums.AttackType.Yell)
            {
                enemyAttackChance = _enemy.Data.DataSkills.Get<Charisma>().GetHitChance();
                playerDefenceChance = _player.Data.DataSkills.Get<Charisma>().GetDefenceChance();
            }
            else
            {
                enemyAttackChance = _enemy.Data.DataSkills.Get<Attack>().GetHitChance(attackType);
                playerDefenceChance = _player.Data.DataSkills.Get<Defence>().GetDefenceChance(attackType);
            }

            var totalChance = Mathf.Clamp(enemyAttackChance - playerDefenceChance, 1, 99);
            var randomChance = UnityEngine.Random.Range(0, 101);

            return randomChance <= totalChance;
        }
    }
}
