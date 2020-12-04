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
        public int delay = 0;
        public bool spatial = false;
        public AudioClip[] clips;
    }
}