using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickups : MonoBehaviour 
{
    static int bananaCount = 0;

    private Text bananaCountText;

    private AudioSource audioSource;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    private void Start()
    {
        bananaCountText = GameObject.Find("PickupText").GetComponent<Text>();
        bananaCountText.text = "PB and Banana Sandwiches made: " + bananaCount;
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PeanutButter")
        {
            audioSource.Play();
            //increments that banana count
            bananaCount++;
            bananaCountText.text = "PB and Banana Sandwiches made: " + bananaCount;
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;

            //Destroy(gameObject);
        }


    }
}
