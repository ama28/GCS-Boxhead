﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicLooper : MonoBehaviour
{
    [SerializeField]
	public AudioSource audio;
    [SerializeField]
    public AudioClip bossMusic;
    [SerializeField]
    public AudioClip levelMusic;
    //unserialize these 2 once timing is determined
	[SerializeField]
	public int loopSamples;
	[SerializeField]
	public int startDelay;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Boss") {
            audio.clip = bossMusic;
            loopSamples = 5380200;
            startDelay = 2006550;
        } else {
            audio.clip = levelMusic;
            loopSamples = 8173701;
            startDelay = 594200;
            audio.Play();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(audio.timeSamples > loopSamples) {
        	audio.timeSamples = startDelay;
        }
    }
}
