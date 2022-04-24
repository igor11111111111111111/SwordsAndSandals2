using System.Reflection;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

namespace SwordsAndSandals
{
    public class ClothChanger : MonoBehaviour
    {
        [SerializeField] private SpriteResolver _helmet;
        [SerializeField] private SpriteResolver _cuirass;
        [SerializeField] private SpriteResolver _shorts;
        [SerializeField] private SpriteResolver _leftFoot;
        [SerializeField] private SpriteResolver _rightFoot;
        [SerializeField] private SpriteResolver _leftGaiter;
        [SerializeField] private SpriteResolver _rightGaiter;
        [SerializeField] private SpriteResolver _leftLeggins;
        [SerializeField] private SpriteResolver _rightLeggins;
        [SerializeField] private SpriteResolver _leftMitten;
        [SerializeField] private SpriteResolver _rightMitten;
        [SerializeField] private SpriteResolver _leftPauldron;
        [SerializeField] private SpriteResolver _rightPauldron;
        [SerializeField] private SpriteResolver _sword;
        [SerializeField] private SpriteResolver _shield;

        [SerializeField] private FallenArmor _fallenArmorPrefab;

        public void SetAll(PlayerData playerData)
        {
            var armors = playerData.DataArmors.Array;
            var weapon = playerData.DataWeapons.Current;

            foreach (var armor in armors)
            {
                Set(armor);
            }

            Set(weapon);
        }

        public void Set(Weapon weapon)
        {
            SpriteResolver sr = null;

            if (weapon is Sword)
                sr = _sword;

            sr.SetCategoryAndLabel(weapon.Name, weapon.Level.ToString());
        }

        public void Set(Armor armor)
        {
            var sr = GetSpriteResolver(armor);
            sr.SetCategoryAndLabel(armor.Name, armor.Level.ToString());
        }

        public void Drop(PlayerDataArmors armors)
        {
            foreach (var armor in armors.Array)
            {
                if(armor.Level > 0)
                {
                    armor.Level = 0;
                    var sr = GetSpriteResolver(armor);
                    var fallenArmor = Instantiate(_fallenArmorPrefab, sr.transform.position, Quaternion.identity);
                    fallenArmor.Init(sr.GetComponent<SpriteRenderer>());
                    sr.SetCategoryAndLabel(armor.Name, "0");

                    break;
                }
            }
        }

        public SpriteResolver GetSpriteResolver(Armor armor)
        {
            SpriteResolver sr = null;

            if (armor is Helmet)
                sr = _helmet;
            else if (armor is Cuirass)
                sr = _cuirass;
            else if (armor is Shorts)
                sr = _shorts;
            else if (armor is LeftFoot)
                sr = _leftFoot;
            else if (armor is RightFoot)
                sr = _rightFoot;
            else if (armor is LeftGaiter)
                sr = _leftGaiter;
            else if (armor is RightGaiter)
                sr = _rightGaiter;
            else if (armor is LeftLeggins)
                sr = _leftLeggins;
            else if (armor is RightLeggins)
                sr = _rightLeggins;
            else if (armor is LeftMitten)
                sr = _leftMitten;
            else if (armor is RightMitten)
                sr = _rightMitten;
            else if (armor is LeftPauldron)
                sr = _leftPauldron;
            else if (armor is RightPauldron)
                sr = _rightPauldron;
            else if (armor is Shield)
                sr = _shield;

            return sr;
        }
    }
}
