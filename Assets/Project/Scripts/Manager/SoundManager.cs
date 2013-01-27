using System.Collections;
using Assets.Scripts.Singleton;
using UnityEngine;
using Holoville.HOTween;

namespace Assets.Project.Scripts.Manager
{
    public class SoundManager : MonoBehaviour
    {

        public AudioClip HeartBeat;
        public AudioClip Breathing;
        public AudioClip Walk;
        public AudioClip Run;
        public AudioClip AmbientMusic;
        public AudioSource HeartbeatAudioSource;
        public AudioSource AmbienceSource;
        public AudioSource MovementSource;
        public AudioSource BreathingSource;

        private static SoundManager instance;
        private bool lerpAudioOn = false;

        void Awake()
        {
            if (AmbienceSource == null)
                AmbienceSource = gameObject.AddComponent<AudioSource>();
            if (MovementSource == null)
                MovementSource = gameObject.AddComponent<AudioSource>();
            if (BreathingSource == null)
                BreathingSource = gameObject.AddComponent<AudioSource>();
            if (HeartbeatAudioSource == null)
                HeartbeatAudioSource = gameObject.AddComponent<AudioSource>();

            if (instance == null) instance = this;
            
            if (HeartbeatAudioSource != null)
            {
                HeartbeatAudioSource.clip = HeartBeat;
                HeartbeatAudioSource.pitch = Player.Instance.Rate;
                HeartbeatAudioSource.loop = true;
                HeartbeatAudioSource.Play();
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
            StartCoroutine(LerpAudio(HeartbeatAudioSource.pitch, Player.Instance.Rate));
            if (Player.Instance.HeartHealth >= 30)
                PlayBreathing();
            else
                StopBreathing();
        }

        IEnumerator LerpAudio(float startPitch, float endPitch)
        {
            if(!lerpAudioOn)
            {
                lerpAudioOn = true;
                var i = 0.0f;
                //var rate = 1.0f/10.0f;
                while (i < 1.0f)
                {
                    i += Time.deltaTime * 0.00001f;
                    HeartbeatAudioSource.pitch = Mathf.Lerp(startPitch, endPitch, i);
                    yield return null;
                }
                lerpAudioOn = false;
            }
            
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
            if(!MovementSource.isPlaying)
            {
                if (running)
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
        }
        public void StopMovement()
        {
            MovementSource.Stop();
        }

        void Update()
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
            {
                if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
                    PlayMovement(true);
                else
                    PlayMovement(false);
            }
            if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S))
            {
                StopMovement();
            }
        }
    }
}
