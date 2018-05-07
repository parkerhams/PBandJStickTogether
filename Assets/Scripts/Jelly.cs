using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using EZCameraShake;

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
    Animator resultsPanelAnim;

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
    private Rigidbody2D jellyRB;

    [SerializeField]
    string nextScene;

    private SpriteRenderer jellyspriteRenderer;

    void Start ()
	{
        //resultsUI.SetActive(false);
        resultsPanelAnim.SetBool("resultsAreActive", false);
        jellyUI.gameObject.SetActive(false);
        jellyspriteRenderer = GetComponent<SpriteRenderer>();
        jellyspriteRenderer.sprite = defaultSprite;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.gameObject.tag == "PeanutButter")
        {
            HitPBLevelOver();
        }
    }

    void HitPBLevelOver()
    {
        float dist = Vector3.Distance(peanutButterTransform.position, transform.position);
        Instantiate(sandwichEffect, transform.position, Quaternion.identity);

        jellyspriteRenderer.sprite = kissSprite;
        pbPlayerUI.gameObject.SetActive(true);
        pbSpriteRenderer.sprite = pbKissSprite;

        CameraShaker.Instance.ShakeOnce(4f, 3f, .1f, 1.5f);

        //jellyRB.angularDrag = 0;

        float percentage = (dist / dist) * 100;
        resultsUI.SetActive(true);
        jellyUI.gameObject.SetActive(true);

        resultsPanelAnim.SetBool("resultsAreActive", true);
        accuracyText.text = "Delicious!\nAccuracy: " + percentage + "%";

        smoochSound.Play();
        //StartCoroutine(WaitForTimeToPause());

        //Time.timeScale = 0;
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

	void End()
	{
		Instantiate(sandwichEffect, transform.position, Quaternion.identity);
	}

}
