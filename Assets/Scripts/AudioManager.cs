using System;
using UnityEngine;

namespace SpaceShooter
{//pogledaj Sound i AudioManager u TileVania s gitHub-a!!
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        public Sound[] sounds;
        [SerializeField] float _fadeOutTime = 1f; //should be the same as the scene fade out animation
        [SerializeField] float _fadeInTime = 1f; 

        private void Awake()
        {
            #region Singleton
            if (instance != null)
            {
                //instance.gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            #endregion

            SoundSetup();
        }

        private void Start()
        {
            LevelManager.onSceneLoaded += FadeInLevelTheme;
            LevelManager.onSceneOver += FadeOutLevelTheme;

            //unsubscribe where?? check what happens on scene change!
        }

        private void SoundSetup()
        {
            foreach (Sound sound in sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;
                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
                sound.source.loop = sound.loop;
            }
        }

        public void Play (string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }

            s.source.Play();
        }

        public void Stop(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }

            s.source.Stop();
        }

        public void FadeOut(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }

            StartCoroutine(AudioFade.CO_FadeOut(s, _fadeOutTime));
        }

        public void FadeIn(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }

            StartCoroutine(AudioFade.CO_FadeIn(s, _fadeInTime));
        }

        private void FadeInLevelTheme()
        {
            AudioClip clip = LevelManager.instance.LevelTheme;

            Sound s = Array.Find(sounds, sound => sound.name == "Theme");
            s.source.clip = clip;

            StartCoroutine(AudioFade.CO_FadeIn(s, _fadeInTime));
        }

        private void FadeOutLevelTheme()
        {
            FadeOut("Theme");
        }
    }
}
