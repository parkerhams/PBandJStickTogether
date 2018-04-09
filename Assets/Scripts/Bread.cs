using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bread : MonoBehaviour {

	public Rigidbody2D rb;
	public Rigidbody2D hook;

	public float releaseTime = .15f;
	public float maxDragDistance = 2f;

	public GameObject nextBread;

	private bool isPressed = false;

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
	}

	void OnMouseDown ()
	{
		isPressed = true;
		rb.isKinematic = true;
	}

	void OnMouseUp ()
	{
		isPressed = false;
		rb.isKinematic = false;

		StartCoroutine(Release());
	}

	IEnumerator Release ()
	{
		yield return new WaitForSeconds(releaseTime);

		GetComponent<SpringJoint2D>().enabled = false;
		this.enabled = false;

		yield return new WaitForSeconds(2f);

		if (nextBread != null)
		{
			nextBread.SetActive(true);
		} else
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	
	}

}
