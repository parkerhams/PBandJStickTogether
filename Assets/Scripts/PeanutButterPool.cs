using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeanutButterPool : MonoBehaviour
{

    //Queue is a line - there's an object in front, an object behind it, etc. 
    //Dequeue takes the first object from the list and then hands it over to, in this case, . InQueue puts an  item at the very bottom of a list.
    //The bread, the script that controls the PeanutButter, 
    //There would be a method here called DRawToast - and it would dequeue, ir remove to the front of the line, and give it to the toaster.
    //The toaster says, okay this is what the camera should be following. 

    public PeanutButter[] peanutButterPlayer;

    void PeanutButterSpawner()
    {
        PeanutButter prefab = peanutButterPlayer[Random.Range(0, peanutButterPlayer.Length)];
        PeanutButter spawn = Instantiate<PeanutButter>(prefab);
        spawn.transform.localPosition = transform.position;
    }
}
