using UnityEngine;

namespace SoundManager.SoundManagerTests
{
    [RequireComponent(typeof(AudioSource))]
    public class SFXPlayer : MonoBehaviour
    {
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound(SFXSound sound)
        {
            sound.PlaySound(audioSource);
        }

    }
}