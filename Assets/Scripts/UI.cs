using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{
    public TextMeshProUGUI title;
    public Image oneGreenMask;
    public Image oneBlackMask;
    public Image twoGreenMask;
    public Image twoBlackMask;
    public Image threeGreenMask;
    public Image threeBlackMask;

    public Button restartButton;

    public Sphere sphereOne;
    public Sphere sphereTwo;
    public Sphere sphereThree;

    // Start is called before the first frame update
    void Start()
    {
        

        restartButton.onClick.AddListener(TaskOnClickRestart);

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
        restartButton.gameObject.SetActive(false);
        StartCoroutine(FadeTextToFullAlpha(5f, title));

    }

    public void TaskOnSceneTwo()
    {
        title.text = "";
        restartButton.gameObject.SetActive(false);
        sphereOne = GameObject.Find("Sphere1").GetComponent<Sphere>();
        sphereTwo = GameObject.Find("Sphere2").GetComponent<Sphere>();
        sphereThree = GameObject.Find("Sphere3").GetComponent<Sphere>();
		Debug.Log ("You are in Scene Two!");

    }

    public void TaskOnSceneThree()
    {
        //restartButton.gameObject.SetActive(true);
        oneBlackMask.gameObject.SetActive(true);
        oneGreenMask.gameObject.SetActive(false);

        twoBlackMask.gameObject.SetActive(true);
        twoGreenMask.gameObject.SetActive(false);

        threeBlackMask.gameObject.SetActive(false);
        threeGreenMask.gameObject.SetActive(true);
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

    void TaskOnClickRestart()
    {
        Scene currentScene = SceneManager.GetActiveScene ();

        restartButton.gameObject.SetActive(false);
        
        SceneManager.LoadScene("Scene-1");
    }



    void update()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
   
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Scene-1")
        {
            oneBlackMask.gameObject.SetActive(false);
            oneGreenMask.gameObject.SetActive(true);

            twoBlackMask.gameObject.SetActive(true);
            twoGreenMask.gameObject.SetActive(false);

            threeBlackMask.gameObject.SetActive(true);
            threeGreenMask.gameObject.SetActive(false);


        }
        else if(sceneName == "Scene-2")
        {
            oneBlackMask.gameObject.SetActive(true);
            oneGreenMask.gameObject.SetActive(false);

            twoBlackMask.gameObject.SetActive(false);
            twoGreenMask.gameObject.SetActive(true);

            threeBlackMask.gameObject.SetActive(true);
            threeGreenMask.gameObject.SetActive(false);

        }
        else if(sceneName == "Scene-3")
        {
            oneBlackMask.gameObject.SetActive(true);
            oneGreenMask.gameObject.SetActive(false);

            twoBlackMask.gameObject.SetActive(true);
            twoGreenMask.gameObject.SetActive(false);

            threeBlackMask.gameObject.SetActive(false);
            threeGreenMask.gameObject.SetActive(true);

        }


       
       

    }
}
