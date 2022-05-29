using CustomJson;
using SwordsAndSandals.OutScene;
using SwordsAndSandals.Tournament;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.PreArena
{
    public class EnterToTournamentButton : MonoBehaviour
    { 
        [SerializeField] private GameObject _body;
        [SerializeField] private Button _button;
         
        public void Init(bool active)
        {
            _body.SetActive(active);

            if (active)
            {
                _button.onClick.AddListener(() => 
                {
                    var json = new Json();
                    var tournamentData = json.Load<TournamentData>();

                    var go = Instantiate(new GameObject());
                    go.name = "TournamentDataScene";
                    var data = go.AddComponent<TournamentDataDontDestroy>();
                    var notCompleteTournament = tournamentData.GetFirstComplete(false);
                    var index = Array.IndexOf(tournamentData.Array, notCompleteTournament);
                    data.Init(new AllTournamentData().List[index]);

                    new SceneChanger().MoveTo(Enums.Scene.Tournament);
                });
            }
        }
    }
}
