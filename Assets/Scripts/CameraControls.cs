using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float zoomStrength = 80f;
    public float rotationSpeed = 50
    ;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the input values from the arrow keys
        float horizontal = Input.GetAxis("Horizontal");  //for rotation: clockwise and anticlockwise
        float vertical = Input.GetAxis("Vertical"); //for zoom in and out

        Vector3 rot =  new Vector3(0.0f, Input.GetAxis("Horizontal"), 0.0f);
        transform.Rotate(rot * rotationSpeed * Time.deltaTime);

        Vector3 newPosition = transform.position + (transform.forward * vertical * zoomStrength * Time.deltaTime);
        transform.position = newPosition;
        
    }
}
