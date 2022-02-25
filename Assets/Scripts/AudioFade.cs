using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public static class AudioFade
    {
        public static IEnumerator CO_FadeOut(Sound sound, float fadeOutTime)
        {
            float startVolume = sound.source.volume;

            while (sound.source.volume > 0)
            {
                sound.source.volume -= startVolume * Time.deltaTime / fadeOutTime;
                yield return null;
            }

            sound.source.Stop();
            sound.source.clip = null;
            sound.source.volume = startVolume;
        }

        public static IEnumerator CO_FadeIn (Sound sound, float fadeInTime)
        {
            float goalVolume = sound.source.volume;
         
            sound.source.volume = 0f;
            sound.source.Play();

            while (sound.source.volume < goalVolume)
            {
                sound.source.volume += goalVolume / fadeInTime*Time.deltaTime;
                yield return null;
            }
        }
    }
}
