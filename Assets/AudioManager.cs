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
        ZombieDeath
    }

    private static Dictionary<Sound, float> soundTimerDictionary;
    private static GameObject soundGameObject;
    private static AudioSource audioSource;

    public static void Initialize() {
        soundTimerDictionary = new Dictionary<Sound, float>();
    }

    public static void PlaySound(AudioManager.Sound name, Vector3 position) {
        if(soundGameObject == null) {
            soundGameObject = new GameObject("Sound");
            audioSource = soundGameObject.AddComponent<AudioSource>();
        }
        soundGameObject.transform.position = position;
        SoundAssets.SoundEffect soundEffect = GetSoundEffect(name);
        //checking if we can play the sound 
        //if delay is set but not in dictionary, add to dictionary
        if(soundEffect.delay != 0) {
            if(!soundTimerDictionary.ContainsKey(name)) {
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
        audioSource.spatialBlend = 0.6f;
        audioSource.spread = 174f;
        if(soundEffect.pitchVariation) {
            audioSource.pitch = 1 + Random.Range(-0.1f, 0.1f);
        }

        audioSource.PlayOneShot(clip);
        Object.Destroy(soundGameObject, audioSource.clip.length);
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
