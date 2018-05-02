using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jelly : MonoBehaviour
{

	public GameObject sandwichEffect;

    [SerializeField]
    AudioSource smoochSound;

    [SerializeField]
    public float endPauseTime = 4f;

    [SerializeField]
    GameObject resultsUI;

    public Canvas jellyUI;

	//public static int EnemiesAlive = 0;

    [SerializeField]
    Text accuracyText;

    [SerializeField]
    Transform peanutButterTransform;

    [SerializeField]
    string nextScene;

	void Start ()
	{
        //EnemiesAlive++;
        resultsUI.SetActive(false);
        jellyUI.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D colInfo)
    {
        //if (colInfo.relativeVelocity.magnitude > health)
        //{
        //    Die();
        //}
        if (colInfo.gameObject.tag == "PeanutButter")
        {
            float dist = Vector3.Distance(peanutButterTransform.position, transform.position);
            Instantiate(sandwichEffect, transform.position, Quaternion.identity);
            float percentage = (dist / dist) * 100;
            resultsUI.SetActive(true);
            jellyUI.gameObject.SetActive(true);
            accuracyText.text = "Delicious!\nAccuracy: " + percentage + "%";
            smoochSound.Play();
            //StartCoroutine(WaitForTimeToPause());

            Time.timeScale = 0;
        }
    }

    public void OnStartButtonClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nextScene);
    }
	

    IEnumerator WaitForTimeToPause()
    {
        Debug.Log("This CoRoutine is waiting two seconds to pause");
        yield return new WaitForSeconds(endPauseTime);
        Time.timeScale = 0;
        
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
