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
        public AudioClip Flatline;
        public AudioSource HeartbeatAudioSource;
        public AudioSource AmbienceSource;
        public AudioSource MovementSource;
        public AudioSource BreathingSource;
        public AudioSource FlatlineSource;

<<<<<<< HEAD
=======
        private VisManager VisManager;
>>>>>>> commit this shit
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
            if (FlatlineSource == null) FlatlineSource = gameObject.AddComponent<AudioSource>();

            if (instance == null) instance = this;
            
            if (HeartbeatAudioSource != null)
            {
                HeartbeatAudioSource.clip = HeartBeat;
                HeartbeatAudioSource.pitch = (Player.Instance.Rate == 0) ? 1 : Player.Instance.Rate;
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

            if (BreathingSource != null)
            {
                BreathingSource.clip = Breathing;
                BreathingSource.loop = true;
            }

            if (FlatlineSource != null)
            {
                FlatlineSource.clip = Flatline;
                FlatlineSource.volume = 0.5f;
            }
<<<<<<< HEAD
=======

            VisManager = this.GetComponentInChildren<VisManager>();
            VisManager.audioSource = HeartbeatAudioSource;

>>>>>>> commit this shit
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
                    i += Time.deltaTime * 1f;
                    HeartbeatAudioSource.pitch = Mathf.Lerp(startPitch, endPitch, i);
                    yield return null;
                }
                lerpAudioOn = false;
            }
            
        }

        public void YoureFuckingDead(bool isrlyDed)
        {
            if (isrlyDed)
            {
                HeartbeatAudioSource.Stop();
                FlatlineSource.Play();
            }
            else
            {
                FlatlineSource.Stop();
                HeartbeatAudioSource.Play();
            }
        }

        public void PlayBreathing()
        {
            Debug.Log("Pitch Rate: " + Player.Instance.Rate);
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
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
                    PlayMovement(true);
                else
                    PlayMovement(false);
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                StopMovement();
            }
        }
    }
}
