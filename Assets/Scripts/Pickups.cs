using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickups : MonoBehaviour 
{
    [SerializeField]
    GameObject pickupText;

    private void Start()
    {
        pickupText.SetActive(false);
    }

    public void OnCollisionEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PeanutButter"))
        {
            Destroy(this.gameObject);
            pickupText.SetActive(true);
        }
    }
}
