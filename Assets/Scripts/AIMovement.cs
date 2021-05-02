using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;

    [SerializeField] private FindTargetInRange find;
    private Transform target;
    private NavMeshAgent agent;
    private float timer = 3f;

    private void OnEnable()
    {
        EventManager.OnFindOppenent.AddListener(GoTarget);
    }
    private void OnDisable()
    {
        EventManager.OnFindOppenent.RemoveListener(GoTarget);
    }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer && !agent.hasPath)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    private void GoTarget()
    {
        target = find.closestTarget;
        agent.SetDestination(target.position);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
