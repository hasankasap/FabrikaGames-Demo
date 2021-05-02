using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailCheckScript : MonoBehaviour
{
    [SerializeField] private GameObject failPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Opponent"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            failPanel.SetActive(true);
            Debug.Log("Fail"); // buraya fail için ui ekleyebiliriz
        }
    }
}
