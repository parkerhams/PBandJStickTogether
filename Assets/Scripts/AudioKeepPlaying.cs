using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioKeepPlaying : MonoBehaviour
{

    private static AudioKeepPlaying instance = null;
    public static AudioKeepPlaying InstanceOfAudio
    {
        get { return instance; }

    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
