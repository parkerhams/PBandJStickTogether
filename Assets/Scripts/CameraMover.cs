using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField]
    Camera theRealCamera;

    private bool coroutineIsRunning;
    private void Start()
    {
        theRealCamera.gameObject.SetActive(false);
        coroutineIsRunning = false;
        StartCoroutine(DisableCamera());
    }

    IEnumerator DisableCamera()
    {
        coroutineIsRunning = true;
        yield return new WaitForSeconds(4f);
        if(coroutineIsRunning == true)
        {
            this.gameObject.SetActive(false);
            theRealCamera.gameObject.SetActive(true);
        }
    }
}
