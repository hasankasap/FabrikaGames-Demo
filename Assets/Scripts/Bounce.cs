using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bounce : MonoBehaviour
{
    BoxCollider boxCollider;
    NavMeshAgent agent;
    private AIMovement ai;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        boxCollider = GetComponent<BoxCollider>();
        ai = gameObject.GetComponent<AIMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Opponent"))
        {
            //Vector3 pushVector = transform.position - collision.transform.position;
            //collision.gameObject.GetComponent<Rigidbody>().AddForce(pushVector * 2f,ForceMode.Impulse);

            StartCoroutine(wait());

        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
            //Vector3 PushVector = transform.position - collision.transform.position;
            // collision.gameObject.GetComponent<Rigidbody>().AddForce(PushVector * 2f, ForceMode.Impulse);
            StartCoroutine(wait());
        }

    }

    IEnumerator wait()
    {
        var temp = boxCollider.material;
        boxCollider.material = null;
        agent.enabled = false;
        ai.enabled = false;
        yield return new WaitForSeconds(1.5f);
        boxCollider.material = temp;
        agent.enabled = true;
        ai.enabled = true;
    }
}
