using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PeanutButter: MonoBehaviour
{

	public Rigidbody2D rb;
	public Rigidbody2D hook;

	public float releaseTime = .15f;
	public float maxDragDistance = 2f;

	public GameObject nextBread;
    public Canvas pbPlayerUI;

    [SerializeField]
    AudioSource toasterDown;
    [SerializeField]
    AudioSource toasterUp;

    [SerializeField]
    Sprite defaultSprite;

    //[SerializeField]
    //public float upwardVelocity = new Vector2(1f, 5f);

    private bool isPressed = false;

    private SpriteRenderer pbSpriteRenderer;

    private void Start()
    {
        pbPlayerUI.gameObject.SetActive(false);
        pbSpriteRenderer = GetComponent<SpriteRenderer>();
        pbSpriteRenderer.sprite = defaultSprite;
}

    void Update ()
	{
		if (isPressed)
		{
            //Mouse Input with aid from Unity API's and from Asbjorn 
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //this is supposed to 
			if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
				rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
			else
				rb.position = mousePos;
		}

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

	void OnMouseDown ()
	{
		isPressed = true;
        if (isPressed)
        {
            toasterDown.Play();
            rb.isKinematic = true;
        }
	}

	void OnMouseUp ()
	{
		isPressed = false;
        if (isPressed == false)
        {
            toasterUp.Play();
            rb.isKinematic = false;
        }

		StartCoroutine(Release());
	}

    IEnumerator DisplayInstructionsToRestartText()
    {
        yield return new WaitForSeconds(5f);
    }

	IEnumerator Release ()
	{
		yield return new WaitForSeconds(releaseTime);

		GetComponent<SpringJoint2D>().enabled = false;
		this.enabled = false;

        yield return new WaitForSeconds(3f);

        if (nextBread != null)
        {
            nextBread.SetActive(true);
            //Destroy(this.gameObject);
        }        //else
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}


    }

    IEnumerator HitGroundLevelReload()
    {
        yield return new WaitForSeconds(3f);

        if (nextBread != null)
        {
            nextBread.SetActive(true);
            //Destroy(this.gameObject);
        }
        //else
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Jelly")
        {
            rb.angularDrag = 0;
            //this.rb.angularVelocity = Vector3.zero;
        }
        if(collision.gameObject.tag == "Banana")
        {
            collision.gameObject.SetActive(false);
        }
    }

}
