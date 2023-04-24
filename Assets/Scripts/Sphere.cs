using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sphere : MonoBehaviour
{
    public GameObject target;
    public int speed = 20;
    public bool sphereSelected;
    public GameObject mainCamera;

    public bool fadedOut;
    public bool reachedCentre;

    void start()
    {
        fadedOut = false;
        reachedCentre = false;

    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Scene-2")
        {
            transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime);
            Debug.Log(this.gameObject.name + " is Selected : " + sphereSelected.ToString());

        }
        else if(sceneName == "Scene-3")
        {
            if(!sphereSelected)
            {
                Debug.Log("Fading out : " +this.gameObject.name);
                if(!fadedOut)
                {
                    FadeOut(this.gameObject);
                }
            }
            else
            {
                if(!reachedCentre)
                {
                    Debug.Log("Moving to Centre : " +this.gameObject.name);
                    MovetoCentre(mainCamera.transform, this.gameObject);
                }
                
            }
        }
       
    }

    public void MovetoCentre(Transform cameraTransform, GameObject gameObject)
    {
        Vector3 targetTransform = new Vector3(gameObject.transform.position.x, cameraTransform.position.y, gameObject.transform.position.z);
        cameraTransform.position = Vector3.MoveTowards(targetTransform, Vector3.zero, 0.00001f * Time.deltaTime);
        Debug.Log("Moving Object to Centre");

        if (Vector3.Distance(cameraTransform.position, targetTransform) < 0.05f)
        {
            reachedCentre = true;
        }

    }

    public void FadeOut(GameObject gameObject)
    {
        Debug.Log("Fading Out");

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
}


