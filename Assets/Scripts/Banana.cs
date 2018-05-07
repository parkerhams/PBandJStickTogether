using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Banana : MonoBehaviour
{
    static int bananaCount = 0;

    [SerializeField]
    Text bananaCountText;

    private AudioSource audioSource;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    //void OnPlayerRespawnedFromCheckpoint()
    //{
    //    ReenableCoin();
    //    bananaCount = 0;
    //    UpdateBananaText();
    //}

    void ReenableCoin()
    {
        spriteRenderer.enabled = true;
        boxCollider2D.enabled = true;
    }

    void UpdateBananaText()
    {
        bananaCountText.text = "Bananas: " + bananaCount;
    }

    void Start()
    {
        UpdateBananaText();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D pbcol)
    {
        //Based on what we know, when OnTriggerEnter2D is called we have a collision parameter is called.
        if (pbcol.gameObject.tag == "PeanutButter")
        {
            audioSource.Play();
            //increments that coin count
            bananaCount++;
            UpdateBananaText();
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
        }


    }
}
