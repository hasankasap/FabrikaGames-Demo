using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float forwardSpeed = 5f;
    [SerializeField]private float turningSpeed = 10f;
    
    Vector3 fingerFirstPosition;
    Vector3 fingerDirection;

    [HideInInspector]public bool goForward = true;
    [HideInInspector]public bool goBack = false;
    void Update()
    {

        SwerveInput();
        fingerDirection.x = Mathf.Clamp(fingerDirection.x, -5, 5);
        transform.Rotate(fingerDirection.x * Vector3.up * Time.deltaTime * turningSpeed);

    }

    public void SwerveInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fingerFirstPosition = Input.mousePosition; // get first touch
            
        }
        else if (Input.GetMouseButton(0))
        {
            fingerDirection = Input.mousePosition - fingerFirstPosition; // get finger moving direction

            if (goBack)
            {
                transform.Translate(Vector3.back * forwardSpeed * Time.deltaTime);
            }

            if (goForward)
            {
                transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            fingerDirection = Vector3.zero;         // stoping movement when finger up
        }
    }

    public void GoForward()
    {
        goForward = true;
        goBack = false;
    }

    public void GoBack()
    {
        goBack = true;
        goForward = false;
    }
}
