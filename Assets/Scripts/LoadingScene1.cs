using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour 
{
    private static string sceneToLoad = "Level1";

    [SerializeField]
    private Slider progressBarSlider;

    private void Start()
    {
        //var task = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
        StartCoroutine(LoadSceneAsync(sceneToLoad));
        //float seconds = 3f;
        //float timeStamp = Time.fixedTime + seconds;
        //if(Time.fixedTime == timeStamp)
        //{
        //    progressBarSlider.value = task.progress;
        //}
        //progressBarSlider.value = 1;
        //SceneManager.UnloadSceneAsync("Loading Scene");

    }

    //If you call float timeStamp = time.FixedTime + seconds; (you're capturing the seconds it is right now + the seconds you want in the future
    //When you call it you put if(time.FixedTime == timeStamp)
    //{ //call code to load the slider }
    //You ca nload the loadingscene Canvas first and then call the if(time.FixedTime)


    private IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return new WaitForSeconds(2f);

        var task = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
        float seconds = 3f;
        float timeStamp = Time.fixedTime + seconds;
        if (Time.fixedTime == timeStamp)
        {
            while (!task.isDone)
            {
                progressBarSlider.value = task.progress;
                yield return null;
            }
            progressBarSlider.value = 1;
        }

        yield return new WaitForSeconds(2f);
        SceneManager.UnloadSceneAsync("LoadingScene");

    }

    public static void StartLoadingScene(string nameOfSceneToLoad)
    {
        sceneToLoad = nameOfSceneToLoad;
        SceneManager.LoadScene("LoadingScene");
    }
}