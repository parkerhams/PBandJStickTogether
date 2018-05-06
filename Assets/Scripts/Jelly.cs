using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jelly : MonoBehaviour
{
    public Canvas jellyUI;
    public GameObject sandwichEffect;

    public Canvas pbPlayerUI;

    [SerializeField]
    AudioSource smoochSound;

    [SerializeField]
    public float endPauseTime = 4f;

    [SerializeField]
    GameObject resultsUI;

    [SerializeField]
    Sprite kissSprite;
    [SerializeField]
    Sprite defaultSprite;
    [SerializeField]
    Sprite pbKissSprite;

    [SerializeField]
    Text accuracyText;

    [SerializeField]
    Transform peanutButterTransform;
    [SerializeField]
    SpriteRenderer pbSpriteRenderer;

    [SerializeField]
    string nextScene;

    private SpriteRenderer jellyspriteRenderer;

    void Start ()
	{
        resultsUI.SetActive(false);
        jellyUI.gameObject.SetActive(false);
        jellyspriteRenderer = GetComponent<SpriteRenderer>();
        jellyspriteRenderer.sprite = defaultSprite;
    }

    void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.gameObject.tag == "PeanutButter")
        {
            float dist = Vector3.Distance(peanutButterTransform.position, transform.position);
            Instantiate(sandwichEffect, transform.position, Quaternion.identity);
            jellyspriteRenderer.sprite = kissSprite;
            pbPlayerUI.gameObject.SetActive(true);
            pbSpriteRenderer.sprite = pbKissSprite;
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
