using SwordsAndSandals.Arena;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

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

        [SerializeField] private SpriteResolver _sword;
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
            var sr = GetSpriteRenderer(armor);

            var sprites = Resources.LoadAll<Sprite>(armor.SpritesPath);
            sr.sprite = sprites[armor.ID];
        }

        public void Drop(int damage, Vector3 pos)
        {
            foreach (var armor in _playerData.DataArmors.Array)
            {
                if (armor.ID > 0)
                {
                    armor.ID = 0;
                    var sr = GetSpriteRenderer(armor);
                    var fallenArmor = Instantiate(_fallenArmorPrefab, sr.transform.position, Quaternion.identity);
                    fallenArmor.Init(sr, _playerData.Team);
                    sr.sprite = null;

                    break;
                }
            }
        }

        public SpriteRenderer GetSpriteRenderer(Armor armor)
        {
            SpriteRenderer sr = null;

            if (armor.Category == Armor.CategoryEnum.Helmet)
                sr = _helmet;
            else if (armor.Category == Armor.CategoryEnum.Cuirass)
                sr = _cuirass;
            else if (armor.Category == Armor.CategoryEnum.Short)
                sr = _shorts;
            else if (armor.Category == Armor.CategoryEnum.LeftBoot)
                sr = _leftBoot;
            else if (armor.Category == Armor.CategoryEnum.RightBoot)
                sr = _rightBoot;
            else if (armor.Category == Armor.CategoryEnum.LeftGaiter)
                sr = _leftGaiter;
            else if (armor.Category == Armor.CategoryEnum.RightGaiter)
                sr = _rightGaiter;
            else if (armor.Category == Armor.CategoryEnum.LeftLeggin)
                sr = _leftLeggins;
            else if (armor.Category == Armor.CategoryEnum.RightLeggin)
                sr = _rightLeggins;
            else if (armor.Category == Armor.CategoryEnum.LeftMitten)
                sr = _leftMitten;
            else if (armor.Category == Armor.CategoryEnum.RightMitten)
                sr = _rightMitten;
            else if (armor.Category == Armor.CategoryEnum.LeftPauldron)
                sr = _leftPauldron;
            else if (armor.Category == Armor.CategoryEnum.RightPauldron)
                sr = _rightPauldron;
            else if (armor.Category == Armor.CategoryEnum.Shield)
                sr = _shield;

            return sr;
        }
    }
}
