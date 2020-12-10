using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAssets : MonoBehaviour
{
    private static SoundAssets _i;

    public static SoundAssets i {
        get {
            if(_i == null) {
                _i = Instantiate(Resources.Load<SoundAssets>("SoundAssets"));
                AudioManager.Initialize();
            }
            return _i;
        }
    }

    public SoundEffect[] soundEffectClips;

    [System.Serializable]
    public class SoundEffect
    {
        public AudioManager.Sound name;
        public float volume = 1f;
        public bool pitchVariation = false;
        public float delay = 0f;
        public bool spatial = false;
        public AudioClip[] clips;
    }
}