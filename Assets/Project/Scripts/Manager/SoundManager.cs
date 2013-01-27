using System.Collections;
using Assets.Scripts.Singleton;
using UnityEngine;

namespace Assets.Project.Scripts.Manager
{
    public class SoundManager : MonoBehaviour
    {

        public AudioClip HeartBeat;
        public AudioClip Breathing;
        public AudioClip Walk;
        public AudioClip Run;
        public AudioClip AmbientMusic;
        public AudioListener AbsurdAudioListener;
        public AudioSource AudioSource;
        public AudioSource AmbienceSource;
        public AudioSource MovementSource;
        public AudioSource BreathingSource;

        private static SoundManager instance;

        void Awake()
        {
            if (AmbienceSource == null)
                AmbienceSource = gameObject.AddComponent<AudioSource>();
            if (MovementSource == null)
                MovementSource = gameObject.AddComponent<AudioSource>();
            if (BreathingSource == null)
                BreathingSource = gameObject.AddComponent<AudioSource>();

            if (instance == null) instance = this;
            //AbsurdAudioListener = Camera.mainCamera.GetComponent<AudioListener>();

            if (AbsurdAudioListener != null)
            {
                if (HeartBeat != null && AudioSource != null)
                {
                    AudioSource.clip = HeartBeat;
                    AudioSource.pitch = Player.Instance.Rate;
                    AudioSource.loop = true;
                    AudioSource.Play();
                    // it was a good day
                }
            }
            if (AmbienceSource != null)
            {
                AmbienceSource.clip = AmbientMusic;
                AmbienceSource.loop = true;
                AmbienceSource.volume = .5f;
                AmbienceSource.Play(5);
            }
        }

        public static SoundManager Instance
        {
            get { return instance; }
        }

        public void Refresh()
        {
            StartCoroutine(LerpAudio(AudioSource.pitch, Player.Instance.Rate));
        }

        IEnumerator LerpAudio(float startPitch, float endPitch)
        {
            var i = 0.0f;
            //var rate = 1.0f/10.0f;
            while (i < 1.0f)
            {
                i += Time.deltaTime*0.00001f;
                AudioSource.pitch = Mathf.Lerp(startPitch, endPitch, i);
            }
            yield return null;
        }

        public void PlayBreathing()
        {
            BreathingSource.clip = Breathing;
            BreathingSource.loop = true;
            BreathingSource.Play();
        }
        public void StopBreathing()
        {
            BreathingSource.Stop();
        }

        public void PlayMovement(bool running)
        {
            if(running)
            {
                MovementSource.clip = Run;
            }
            else
            {
                MovementSource.clip = Walk;
            }
            MovementSource.loop = true;
            MovementSource.Play();
        }
        public void StopMovement()
        {
            MovementSource.Stop();
        }
    }
}
