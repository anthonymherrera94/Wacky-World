using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace SoundManager.SoundManagerTests
{
    public class MockSfxSound : SFXSound
    {
        public bool soundPlayed = false;

        public override void PlaySound(AudioSource audioSource)
        {
            soundPlayed = true;
        }
    }

    public class PlayGroupSound
    {
        private MockSfxSound sound1, sound2;
        private int sampleRate = 44000;
        private SfxGroup sfxGroup;

        [UnitySetUp]
        public IEnumerator Setup()
        {
            sound1 = ScriptableObject.CreateInstance<MockSfxSound>();
            sound2 = ScriptableObject.CreateInstance<MockSfxSound>();
            sfxGroup = ScriptableObject.CreateInstance<SfxGroup>();
            sfxGroup.sounds.Add(sound1);
            sfxGroup.sounds.Add(sound2);
            yield return null;
        }

        [UnityTest]
        public IEnumerator PlayOneSound()
        {
            Assert.IsFalse(eitherSoundPlayed);
            sfxGroup.PlaySound(null);
            yield return null;
            Assert.IsTrue(eitherSoundPlayed);
        }

        [UnityTest]
        public IEnumerator PlayInEditor()
        {
            Assert.IsFalse(eitherSoundPlayed);
            sfxGroup.PlayInEditor();
            yield return null;
            Assert.IsTrue(eitherSoundPlayed);
        }

        private bool eitherSoundPlayed => sound1.soundPlayed || sound2.soundPlayed;
    }


    public class PlaySimpleSound
    {
        private MockSfxSound sound;
        private int sampleRate = 44000;

        [UnitySetUp]
        public IEnumerator Setup()
        {
            sound = ScriptableObject.CreateInstance<MockSfxSound>();
            sound.audioClip = AudioClip.Create("testSoundClip", 16, 8, sampleRate, false, OnRead, OnPosition);

            yield return null;
        }

        [UnityTest]
        public IEnumerator PlaySimpleSoundWithEnumeratorPasses()
        {
            GameObject go =
                GameObject.Instantiate(new GameObject());
            go.hideFlags = HideFlags.HideAndDontSave;
            var player = go.AddComponent<SFXPlayer>();
            yield return null;
            Assert.False(sound.soundPlayed);
            player.PlaySound(sound);
            yield return null;
            Assert.IsTrue(sound.soundPlayed);
            yield return null;
        }

        [UnityTest]
        public IEnumerator SoundInEditorDestroysTemp()
        {
            sound.PlayInEditor();
            yield return null;
            yield return null;
            yield return null;
            yield return null;
            Assert.IsTrue(sound.soundPlayed);
            yield return null;
        }

        [UnityTest]
        public IEnumerator PlayInEditorWorks()
        {
            sound.PlayInEditor();
            yield return null;
            Assert.IsTrue(sound.soundPlayed);
            yield return null;
        }

        private void OnPosition(int position)
        {
        }

        private void OnRead(float[] data)
        {
        }
    }
}