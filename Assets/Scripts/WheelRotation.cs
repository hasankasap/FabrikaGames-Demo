using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    Vector3 fingerFirstPosition;
    Vector3 fingerDirection;
    float wheelCurrentRot;
    [SerializeField] private float wheelTurninSpeed = 40f;
    [SerializeField] private GameObject wheel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fingerFirstPosition = Input.mousePosition; // get first touch

        }
        else if (Input.GetMouseButton(0))
        {
            fingerDirection = Input.mousePosition - fingerFirstPosition; // get finger moving direction
            fingerDirection.x = Mathf.Clamp(fingerDirection.x, -5, 5);
            wheelCurrentRot += fingerDirection.x * Time.deltaTime * wheelTurninSpeed ;
            wheelCurrentRot = Mathf.Clamp(wheelCurrentRot, -60f, 60f);
            wheel.transform.localEulerAngles = new Vector3(0, 0, -wheelCurrentRot);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            fingerDirection = Vector3.zero;         // stoping movement when finger up
            wheel.transform.eulerAngles = new Vector3(wheel.transform.eulerAngles.x, wheel.transform.eulerAngles.y, 0);
        }
    }
}
