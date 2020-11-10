using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLooper : MonoBehaviour
{
    [SerializeField]
	public AudioSource audio;
	[SerializeField]
	public int loopSamples;
	[SerializeField]
	public int startDelay;
    // Start is called before the first frame update
    void Start()
    {
        audio.Play();
        audio.time = 179;
    }

    // Update is called once per frame
    void Update()
    {
        if(audio.timeSamples > loopSamples) {
        	audio.timeSamples = startDelay;
        }
    }
}
