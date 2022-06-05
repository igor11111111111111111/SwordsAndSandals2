using SwordsAndSandals.OutScene;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Tournament
{
    public class TournamentPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _info;
        [SerializeField] private TextMeshProUGUI _locationInfo;
        [SerializeField] private Image _icon;
        [SerializeField] private Button _enterToArena;
         
        public void Init(TournamentData data)
        {
            _name.text = data.Name;
            _info.text = data.Info;
            _icon.sprite = Resources.LoadAll<Sprite>("ArenaIcons")[data.IconIndex];
            _locationInfo.text = "This tournament is being held in the " + data.LocationPath;

            _enterToArena.onClick.AddListener(() =>
            new SceneChanger().MoveTo(Enums.Scene.Arena));
        }
    }
}
 