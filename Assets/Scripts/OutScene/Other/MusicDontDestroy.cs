using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals
{
    public class MusicDontDestroy : MonoBehaviour
    {
        public static MusicDontDestroy Instance { get; private set; }
        private static bool _created = false;
        private static AudioSource _audio;
        private static AudioClip[] _music;

        private void Awake()
        {
            if (!_created)
            {
                _audio = gameObject.AddComponent<AudioSource>();
                _music = Resources.LoadAll<AudioClip>("Music");

                DontDestroyOnLoad(this);
                Instance = this;
                _created = true;
            }
            else
            {
                Instance = null;
                Destroy(this);
            }
        }

        public static void SetClip(string name, bool useRandom, bool loop)
        {
            if (!_created || !_audio.enabled || _audio.clip && _audio.clip.name == name) 
                return;


            _audio.Stop();

            var clip = _music.Where(m => m.name == name).FirstOrDefault();
            if (useRandom)
            {
                _audio.time = Random.Range(0, clip.length);
            }
            else
            {
                _audio.time = 0;
            }

            _audio.clip = clip;
            _audio.loop = loop;
            _audio.Play();
        }

        public static void SetVolume(float volume)
        {
            _audio.volume = volume;
        }

        public static void SetActive(bool active)
        {
            _audio.enabled = active;
        }
    }
}


