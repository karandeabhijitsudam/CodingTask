using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{
    public TextMeshProUGUI title;

    // Start is called before the first frame update
    void Start()
    {

        Scene currentScene = SceneManager.GetActiveScene ();
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Scene-1") 
        {
            TaskonSceneOne();
        }
        else if (sceneName == "Scene-2")
        {
            TaskOnSceneTwo();
        }
        else if(sceneName == "Scene-3")
        {
            TaskOnSceneThree();
        }
        
    }


    public void TaskonSceneOne()
    {
        Debug.Log ("You are in Scene One!");
        StartCoroutine(FadeTextToFullAlpha(5f, title));

    }

    public void TaskOnSceneTwo()
    {
        title.text = "";
		Debug.Log ("You are in Scene Two!");

    }

    public void TaskOnSceneThree()
    {
        Debug.Log ("You are in Scene Three!");
    }


    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
        // Using a coroutine to load the Scene in the background
        StartCoroutine(LoadYourAsyncScene("Scene-2"));

    
    }


    public IEnumerator LoadYourAsyncScene(string name)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        
    }
}
