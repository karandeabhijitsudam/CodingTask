using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Selectable : MonoBehaviour
{
    public Material highlightMaterial;
    public Material selectionMaterial;


    private Material originalMaterial;
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;

    private GameObject sceneCentre;

    private GameObject sphereOne;
    private GameObject sphereTwo;
    private GameObject sphereThree;
    public UI ui;
    public GameObject mainCamera;

    public bool isSelected;

    public GameObject spheres;
    


    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        spheres = GameObject.Find("Object");
        sceneCentre = GameObject.Find("SceneCentre");
        sphereOne = GameObject.Find("Sphere1");
        sphereTwo = GameObject.Find("Sphere2");
        sphereThree = GameObject.Find("Sphere3");
        mainCamera = GameObject.Find("Main Camera");
        isSelected = false;
          
    }

    // Update is called once per frame
    void Update()
    {
        
        if(highlight != null)
        {
            highlight.GetComponent<MeshRenderer>().material = originalMaterial;
            highlight = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out raycastHit))
        {
            highlight = raycastHit.transform;

            if(highlight.CompareTag("Selectable") && highlight!=selection)
            {
                if(highlight.GetComponent<MeshRenderer>().material != highlightMaterial)
                {
                    originalMaterial = highlight.GetComponent<MeshRenderer>().material;
                    highlight.GetComponent<MeshRenderer>().material = highlightMaterial;
                }
            }
        }
        else
        {
            highlight = null;
        }


        if(Input.GetKey(KeyCode.Mouse0))
        {
            if(selection!=null)
            {
                selection.GetComponent<MeshRenderer>().material = originalMaterial;
                selection = null;

            }

            //change to selection material on mouse click
            if(Physics.Raycast(ray, out raycastHit))
            {
                selection = raycastHit.transform;
                if(selection.CompareTag("Selectable"))
                {
                    selection.GetComponent<MeshRenderer>().material = selectionMaterial;
                    Debug.Log(selection.name);
                    
                    selection.gameObject.GetComponent<Sphere>().sphereSelected = true;
                    isSelected = true;
                    StartCoroutine(SwitchToSceneThree());
                    
                }
                else
                {
                    selection = null;
                    Debug.Log("Not Selected");
                }

            }
        }

        
    }


    public IEnumerator SwitchToSceneThree()
    {
        Debug.Log("Selected");
        DontDestroyOnLoad(spheres);
        StartCoroutine(ui.LoadYourAsyncScene("Scene-3"));
        yield return null;
    }

}
