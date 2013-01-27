using System.Collections;
using Assets.Scripts.Singleton;
using UnityEngine;

namespace Assets.Project.Scripts.Manager
{
    public class SoundManager : MonoBehaviour
    {

        public AudioClip HeartBeat;
        public AudioListener AbsurdAudioListener;
        public AudioSource AudioSource;
        private static SoundManager instance;

        void Awake()
        {
            if (instance == null) instance = this;
            AbsurdAudioListener = Camera.mainCamera.GetComponent<AudioListener>();

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
    }
}
