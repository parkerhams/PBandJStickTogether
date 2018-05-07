using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainLevel";

    public string creditsLevel = "Credits";

    public string titleLevel = "Title";

    public string tutorialLevel = "TutorialScene";

	public SceneFader sceneFader;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

	public void Play ()
	{
		sceneFader.FadeTo(levelToLoad);
	}

    public void Tutorial()
    {
        sceneFader.FadeTo(tutorialLevel);
    }

    public void Credits()
    {
        sceneFader.FadeTo(creditsLevel);
    }

    public void Title()
    {
        sceneFader.FadeTo(titleLevel);
    }

	public void Quit ()
	{
		Debug.Log("Exiting...");
		Application.Quit();
	}

}
