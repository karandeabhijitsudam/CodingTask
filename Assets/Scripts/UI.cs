using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{
    public Button sceenOneButton;
    public Button sceenTwoButton;
    public Button sceenThreeButton;

    public TextMeshProUGUI title;

    // Start is called before the first frame update
    void Start()
    {
        sceenOneButton.onClick.AddListener(TaskOnClickButtonOne);
        sceenTwoButton.onClick.AddListener(TaskOnClickButtonTwo);
        sceenThreeButton.onClick.AddListener(TaskOnClickButtonThree);


        

        Scene currentScene = SceneManager.GetActiveScene ();
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Scene-1") 
        {
            sceenOneButton.onClick.Invoke();
        }
        else if (sceneName == "Scene-2")
        {
            sceenTwoButton.onClick.Invoke();
        }
        
    }

    void TaskOnClickButtonOne(){
		Debug.Log ("You have clicked the button One!");
        StartCoroutine(FadeTextToFullAlpha(5f, title));
        
	}

    void TaskOnClickButtonTwo(){
        title.text = "";
		Debug.Log ("You have clicked the button Two!");
	}

    void TaskOnClickButtonThree(){
		Debug.Log ("You have clicked the button Three!");
	}

    // Update is called once per frame
    void Update()
    {

        
        
    }

    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }

        
        //SceneManager.LoadScene("Scene-2");
        
        // Use a coroutine to load the Scene in the background
        StartCoroutine(LoadYourAsyncScene());

        

    }


    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scene-2");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        
    }
}
