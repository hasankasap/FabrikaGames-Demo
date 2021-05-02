using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBounce : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Opponent"))
        {
            Vector3 pushVector = transform.position - collision.transform.position;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-pushVector * 2f,ForceMode.Impulse);
        }
    }
}
