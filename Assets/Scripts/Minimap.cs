using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

    //Information courtesy of Brackeys

    public Transform pbPlayer;

    void LateUpdate()
    {
        Vector3 newPosition = pbPlayer.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, pbPlayer.eulerAngles.y, 0f);
    }
}
