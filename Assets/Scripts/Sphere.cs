using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sphere : MonoBehaviour
{
    public GameObject target;
    public int speed = 20;
    public bool sphereSelected;
    public GameObject mainCamera;

    public bool fadedOut;
    public bool fadedIn;
    public bool reachedCentre;
    public GameObject fadeInCube;

    public Color fadeIn;

   

    void start()
    {
        fadedOut = false;
        fadedIn = false;
        reachedCentre = false;

        Color fadeIn = fadeInCube.GetComponent<Renderer>().material.color;
        fadeIn.a = 0f;


    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if(sceneName == "Scene-1")
        {


        }
        else if (sceneName == "Scene-2")
        {

            this.fadeInCube.SetActive(false);
            transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime);
            
        }
        else if(sceneName == "Scene-3")
        {
            
            if(!sphereSelected)
            {

                this.fadeInCube.SetActive(false);
                if(!fadedOut)
                {
                    FadeOut(this.gameObject);
                }
            }
            else
            {

                this.fadeInCube.SetActive(true);

                if(!reachedCentre)
                {
                    Debug.Log("Moving to Centre : " +this.gameObject.name);
                    MovetoCentre(mainCamera.transform, this.gameObject);
                }

                if(!fadedIn)
                {
                    FadeIn(this.fadeInCube);
                }
                
            }
        }
       
    }

    public void MovetoCentre(Transform cameraTransform, GameObject gameObject)
    {
        Vector3 targetTransform = new Vector3(gameObject.transform.position.x, cameraTransform.position.y, gameObject.transform.position.z);
        cameraTransform.position = Vector3.MoveTowards(targetTransform, Vector3.zero, 0.00001f * Time.deltaTime);

        if (Vector3.Distance(cameraTransform.position, targetTransform) < 0.05f)
        {
            reachedCentre = true;
        }

    }

    public void FadeOut(GameObject gameObject)
    {
        Color objectColor = gameObject.GetComponent<Renderer>().material.color;
        float fadeAmount = objectColor.a - (1*Time.deltaTime);

        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
        gameObject.GetComponent<Renderer>().material.color = objectColor;

        if(objectColor.a <= 0)
        {
            Debug.Log("Fade Out done");
            fadedOut = true;
        }

    }

    public void FadeIn(GameObject gameObject)
    {
        Color objectColor = gameObject.GetComponent<Renderer>().material.color;
        Debug.Log(objectColor.a);

        float fadeAmount = objectColor.a + (0.5f*Time.deltaTime);

        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
        gameObject.GetComponent<Renderer>().material.color = objectColor;
        Debug.Log(objectColor.a);
        if(objectColor.a >= 1)
        {
            Debug.Log("Fade In done");
            fadedIn = true;
       
        }

    }

 
}


