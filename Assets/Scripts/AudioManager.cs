using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Audio Manager based off of this tutorial, with modifications:
//https://www.youtube.com/watch?v=QL29aTa7J5Q
public static class AudioManager
{
    public enum Sound {
        Pistol,
        Uzi,
        ZombieHurt,
        HumanHurt,
        DogDeath,
        DogRoar,
        LowHealth,
        HealthPickup,
        ZombieDeath,
        Key,
        GunEmpty,

        Shotgun,
    }

    private static Dictionary<Sound, float> soundTimerDictionary;
    private static GameObject soundGameObject, soundGameObject2;
    private static AudioSource audioSourceNormal, audioSourceSpecial;

    public static void Initialize() {
        soundTimerDictionary = new Dictionary<Sound, float>();
    }

    public static void PlaySound(AudioManager.Sound name, Vector3 position) {
        if(soundGameObject == null) {
            soundGameObject = new GameObject("Sound");
            audioSourceNormal = soundGameObject.AddComponent<AudioSource>();
        }
        if(soundGameObject2 == null) {
            soundGameObject2 = new GameObject("Sound");
            audioSourceSpecial = soundGameObject.AddComponent<AudioSource>();
        }
        AudioSource audioSource = audioSourceNormal;
        if(name == Sound.DogDeath || name == Sound.DogRoar) {
            audioSource = audioSourceSpecial;
        }
        soundGameObject.transform.position = position;
        SoundAssets.SoundEffect soundEffect = GetSoundEffect(name);
        //checking if we can play the sound 
        //if delay is set but not in dictionary, add to dictionary
        if(soundEffect.delay != 0) {
            if(soundTimerDictionary.ContainsKey(name)) {
                float lastTimePlayed = soundTimerDictionary[name];
                if(lastTimePlayed + soundEffect.delay < Time.time) {
                    soundTimerDictionary[name] = Time.time;
                } else {
                    return;
                }
            } else {
                soundTimerDictionary.Add(name, Time.time);
            }
        }

        //adjusting the sound effect via volume, randomization or pitch variation
        AudioClip clip = soundEffect.clips[Random.Range(0, soundEffect.clips.Length-1)];
        audioSource.volume = soundEffect.volume;
        if(soundEffect.spatial) {
            audioSource.spatialBlend = 1f;
            audioSource.spread = 174f;
        } else {
            audioSource.spatialBlend = 0;
        }
        if(soundEffect.pitchVariation) {
            audioSource.pitch = 1 + Random.Range(-0.1f, 0.1f);
        } else {
            audioSource.pitch = 1;
        }

        audioSource.PlayOneShot(clip);
        //Object.Destroy(soundGameObject, audioSource.clip.length);
    }

    private static SoundAssets.SoundEffect GetSoundEffect(AudioManager.Sound name) {
        foreach (SoundAssets.SoundEffect soundEffect in SoundAssets.i.soundEffectClips) {
            if(soundEffect.name == name) {
                return soundEffect;
            }
        }
        Debug.LogError("Sound " + name + " not found!");
        return null;
    }
}
