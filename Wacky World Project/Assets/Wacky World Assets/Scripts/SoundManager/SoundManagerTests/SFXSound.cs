using UnityEngine;

namespace SoundManager.SoundManagerTests
{
    [CreateAssetMenu(fileName = "SfxSound", menuName = Filenames.Folder+"/SFX Sound", order = 0)]
    public class SFXSound : SFX
    {
        public AudioClip audioClip;
        [Range(0, 1)] [SerializeField] public float volume = 0.8f;

        [Header("Pitch")] [SerializeField] public bool randomPitch;
        [Range(0.5f, 2.0f)] [SerializeField] public float pitchMin = 0.8f;
        [Range(0.5f, 2.0f)] [SerializeField] public float pitchMax = 1.2f;
        public override void PlaySound(AudioSource audioSource)
        {
            audioSource.volume = volume;
            audioSource.pitch = randomPitch ? RandomPitch() : 1;
            // audioSource.PlayOneShot(audioClip);
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        private float RandomPitch()
        {
            return Random.Range(pitchMin, pitchMax);
        }

        [ContextMenu(nameof(PlayInEditor))]
        public override void PlayInEditor()
        {
            GameObject go = new GameObject();
            var source = go.AddComponent<AudioSource>();
            go.hideFlags = HideFlags.HideAndDontSave;
            PlaySound(source);
        }
    }
}