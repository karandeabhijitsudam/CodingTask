using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selectable : MonoBehaviour
{
    public Material highlightMaterial;
    public Material selectionMaterial;


    private Material originalMaterial;
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;


    // Start is called before the first frame update
    void Start()
    {
        
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
            if(Physics.Raycast(ray, out raycastHit))
            {
                selection = raycastHit.transform;
                if(selection.CompareTag("Selectable"))
                {
                    selection.GetComponent<MeshRenderer>().material = selectionMaterial;

                }
                else
                {
                    selection = null;
                }

            }
        }
        
    }
}
