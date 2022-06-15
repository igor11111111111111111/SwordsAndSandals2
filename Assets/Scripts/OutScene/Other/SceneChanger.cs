using UnityEngine.SceneManagement;
using UnityEngine;

namespace SwordsAndSandals.OutScene
{
    public class SceneChanger
    {
        public void MoveTo(Enums.Scene scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }
    }
}
