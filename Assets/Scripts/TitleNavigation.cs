using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleNavigation : MonoBehaviour
{
    // Name of next scene
    [SerializeField]
    string nextScene;
    //[SerializeField]
    //Text titleText;
    //[SerializeField]
    //Text toasterText;
    [SerializeField]
    Button startButton;
    //[SerializeField]
    //Button quitButton;
    //[SerializeField]
    //Image heartPB;
    //[SerializeField]
    //Image heartJelly;

    private void Start()
    {
        //toasterText.enabled = false;
        //titleText.enabled = false;
        //startButton.enabled = false;
        //quitButton.enabled = false;
        //heartJelly.enabled = false;
        //heartPB.enabled = false;
    }

    void OnMouseDown()
    {
        //toasterText.enabled = false;
        //titleText.enabled = true;
        //startButton.enabled = true;
        //quitButton.enabled = true;
        //heartJelly.enabled = true;
        //heartPB.enabled = true;

    }

    public void StartButton()
    {
        SceneManager.LoadScene(nextScene);
    }
   
    // Quit the game
    public void QuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
