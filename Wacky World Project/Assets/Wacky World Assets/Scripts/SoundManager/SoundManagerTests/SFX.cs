using UnityEngine;

namespace SoundManager.SoundManagerTests
{
    public abstract class SFX : ScriptableObject
    {
        public abstract void PlaySound(AudioSource audioSource);
        public abstract void PlayInEditor();
    }

    public class Filenames
    {
        public const string Folder = "Sounds";
    }
    

}