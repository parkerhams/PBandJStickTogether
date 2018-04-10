using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jelly : MonoBehaviour {

	public GameObject sandwichEffect;

    [SerializeField]
    AudioSource smoochSound;

	public float health = 4f;

    public Canvas resultsUI;

    public Canvas pbPlayerUI;

    public Canvas jellyUI;

	//public static int EnemiesAlive = 0;

    [SerializeField]
    Text accuracyText;

    [SerializeField]
    Transform peanutButterTransform;

	void Start ()
	{
        //EnemiesAlive++;
        resultsUI.gameObject.SetActive(false);
        pbPlayerUI.gameObject.SetActive(false);
        jellyUI.gameObject.SetActive(false);
    }

	void OnCollisionEnter2D (Collision2D colInfo)
	{
		if (colInfo.relativeVelocity.magnitude > health)
		{
			Die();
		}
        if(colInfo.gameObject.tag == "PeanutButter")
        {
            float dist = Vector3.Distance(peanutButterTransform.position, transform.position);
            float percentage = (dist / dist) * 100;
            resultsUI.gameObject.SetActive(true);
            pbPlayerUI.gameObject.SetActive(true);
            jellyUI.gameObject.SetActive(true);
            accuracyText.text = "Delicious!\nAccuracy: " + percentage + "%";
            smoochSound.Play();
            Time.timeScale = 0;
        }
	}

	void Die ()
	{
		Instantiate(sandwichEffect, transform.position, Quaternion.identity);

		//EnemiesAlive--;
		//if (EnemiesAlive <= 0)
		//	Debug.Log("LEVEL WON!");

		//Destroy(gameObject);
	}

}
