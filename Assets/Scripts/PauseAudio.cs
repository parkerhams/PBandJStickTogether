using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudio : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        //I have a song to loop in other scenes, but if I don't want it to play in certain scenes, 
        //then I will attach this script to camera in whatever scene it should not play in
        AudioKeepPlaying.InstanceOfAudio.gameObject.GetComponent<AudioSource>().Pause();
	}
	
	
}
