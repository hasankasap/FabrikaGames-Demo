using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTargetInRange : MonoBehaviour
{
    [SerializeField] private Transform[] targets;
    [SerializeField] private float range = 5f;
    public Transform closestTarget;

    void Update()
    {
        GetClosest();
    }

    private void GetClosest()
    {
        Vector3 currentPos = transform.position;
        float minDistance = range;
        foreach (Transform t in targets)
        {
            float distance = Vector3.Distance(t.position, currentPos);
            if (distance <= minDistance)
            {
                closestTarget = t;
                minDistance = distance;
                EventManager.OnFindOppenent.Invoke();
            }
        }
    }
}
