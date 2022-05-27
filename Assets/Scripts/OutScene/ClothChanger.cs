using SwordsAndSandals.Arena;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SwordsAndSandals
{
    public class ClothChanger : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _helmet;
        [SerializeField] private SpriteRenderer _cuirass;
        [SerializeField] private SpriteRenderer _shorts;
        [SerializeField] private SpriteRenderer _leftBoot;
        [SerializeField] private SpriteRenderer _rightBoot;
        [SerializeField] private SpriteRenderer _leftGaiter;
        [SerializeField] private SpriteRenderer _rightGaiter;
        [SerializeField] private SpriteRenderer _leftLeggins;
        [SerializeField] private SpriteRenderer _rightLeggins;
        [SerializeField] private SpriteRenderer _leftMitten;
        [SerializeField] private SpriteRenderer _rightMitten;
        [SerializeField] private SpriteRenderer _leftPauldron;
        [SerializeField] private SpriteRenderer _rightPauldron;
        [SerializeField] private SpriteRenderer _shield;

        [SerializeField] private SpriteRenderer _weapon;
        [SerializeField] private FallenArmor _fallenArmorPrefab;
        private PlayerData _playerData;

        public void Init(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public void Init(AttackHandler attackHandler)
        {
            attackHandler.OnTakeDamage += Drop;
        }

        public void SetAll()
        {
            var armors = _playerData.DataArmors.Array;
            var weapon = _playerData.DataWeapons.Current;

            foreach (var armor in armors)
                Set(armor);

            Set(weapon);
        }

        public void Set(Weapon weapon)
        {
            var path = "Weapon/" + weapon.Category.ToString();
            var sprites = Resources.LoadAll<Sprite>(path);
            _weapon.sprite = sprites[weapon.ID];
        }

        public void Set(Armor armor)
        {
            var spriteRenderers = GetSpriteRenderer(armor);
            foreach (var spriteRenderer in spriteRenderers)
            {
                string path = null;
                if(spriteRenderers.Count == 1)// fix later
                {
                    path = "Armor/" + armor.Category.ToString();
                }
                else
                {
                    if(spriteRenderers.IndexOf(spriteRenderer) == 0)
                    {
                        path = "Armor/" + "Left" + armor.Category.ToString();
                    }
                    else if(spriteRenderers.IndexOf(spriteRenderer) == 1)
                    {
                        path = "Armor/" + "Right" + armor.Category.ToString();
                    }
                }//

                var sprites = Resources.LoadAll<Sprite>(path);
                spriteRenderer.sprite = sprites[armor.ID];
            }
        }

        public void Drop(int damage, Vector3 pos)
        {
            foreach (var armor in _playerData.DataArmors.Array)
            {
                if (armor.ID > 0)
                {
                    armor.ID = 0;
                    var srs = GetSpriteRenderer(armor);
                    foreach (var sr in srs)
                    {
                        var fallenArmor = Instantiate(_fallenArmorPrefab, sr.transform.position, Quaternion.identity);
                        fallenArmor.Init(sr, _playerData.Team);
                        sr.sprite = null;
                    }
                    break;
                }
            }
        }

        public List<SpriteRenderer> GetSpriteRenderer(Armor armor)
        {
            List<SpriteRenderer> sr = new List<SpriteRenderer>();

            if (armor.Category == Armor.CategoryEnum.Helmet)
                sr.Add(_helmet);
            else if (armor.Category == Armor.CategoryEnum.Cuirass)
                sr.Add(_cuirass);
            else if (armor.Category == Armor.CategoryEnum.Short)
                sr.Add(_shorts);
            else if (armor.Category == Armor.CategoryEnum.Shield)
                sr.Add(_shield);
            else if (armor.Category == Armor.CategoryEnum.Boot)
            {
                sr.Add(_leftBoot);
                sr.Add(_rightBoot);
            }
            else if (armor.Category == Armor.CategoryEnum.Gaiter)
            {
                sr.Add(_leftGaiter);
                sr.Add(_rightGaiter);
            }
            else if (armor.Category == Armor.CategoryEnum.Leggin)
            {
                sr.Add(_leftLeggins);
                sr.Add(_rightLeggins);
            }
            else if (armor.Category == Armor.CategoryEnum.Mitten)
            {
                sr.Add(_leftMitten);
                sr.Add(_rightMitten);
            }
            else if (armor.Category == Armor.CategoryEnum.Pauldron)
            {
                sr.Add(_leftPauldron);
                sr.Add(_rightPauldron);
            }

            return sr;
        }
    }
}
