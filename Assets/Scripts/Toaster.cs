using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D peanutButter_Rb;
    [SerializeField]
    Rigidbody2D hookRb;

    [SerializeField]
    AudioSource toasterDown;
    [SerializeField]
    AudioSource toasterUp;

    public float releaseTime = .15f;
    public float maxDragDistance = 2f;

    public PeanutButter pbSpawnPrefab;

    private bool isPressed = false;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            //Mouse Input with aid from Unity API's and from Asbjorn 
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //this is supposed to 
            if (Vector3.Distance(mousePos, hookRb.position) > maxDragDistance)
                peanutButter_Rb.position = hookRb.position + (mousePos - hookRb.position).normalized * maxDragDistance;
            else
                peanutButter_Rb.position = mousePos;
        }
    }

    void OnMouseDown()
    {
        isPressed = true;
        if (isPressed)
        {
            toasterDown.Play();
            peanutButter_Rb.isKinematic = true;
        }
    }

    void OnMouseUp()
    {
        isPressed = false;
        if (isPressed == false)
        {
            toasterUp.Play();
            peanutButter_Rb.isKinematic = false;
        }

        StartCoroutine(Release());
    }


    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
    }

    void CreateAndSpawn()
    {
        PeanutButter spawnerPB = Instantiate<PeanutButter>(pbSpawnPrefab);
    }
}
