using System.Collections.Generic;
using UnityEngine;

namespace SoundManager.SoundManagerTests
{
    [CreateAssetMenu(fileName = "SfxGroup", menuName = Filenames.Folder+"/SFX Group", order = 1)]
    public class SfxGroup : SFX
    {
        public List<SFX> sounds = new List<SFX>();
        private SFX Random => sounds[GetRandomIndex()];
        private int GetRandomIndex()
        {
            return UnityEngine.Random.Range(0, sounds.Count);
        }


        public override void PlaySound(AudioSource audioSource)
        {
            Random.PlaySound(audioSource);
        }

        [ContextMenu(nameof(PlayInEditor))]
        public override void PlayInEditor()
        {
            Random.PlayInEditor();
        }

    }
}