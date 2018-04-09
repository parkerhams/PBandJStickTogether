using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jelly : MonoBehaviour {

	public GameObject sandwichEffect;

    [SerializeField]
    AudioSource smoochSound;

	public float health = 4f;

	//public static int EnemiesAlive = 0;

    [SerializeField]
    Text accuracyText;

    [SerializeField]
    Transform peanutButterTransform;

	void Start ()
	{
		//EnemiesAlive++;
	}

	void OnCollisionEnter2D (Collision2D colInfo)
	{
		if (colInfo.relativeVelocity.magnitude > health)
		{
			Die();
		}
        if(CompareTag("PeanutButter"))
        {
            float dist = Vector3.Distance(peanutButterTransform.position, transform.position);
            accuracyText.text = "Accuracy: " + dist % 100;
            smoochSound.Play();
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
