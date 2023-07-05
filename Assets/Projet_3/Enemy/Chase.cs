using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Chase : MonoBehaviour
{
    private SphereCollider visionSphere;
    [SerializeField] private NavMeshAgent agent;

    void Start()
    {
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

    }


    void ChasePlayer(Vector3 position)
    {
        // Set the agent to go to the currently selected destination.
        agent.destination = position;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        //if (!agent.pathPending && agent.remainingDistance < 0.5f)
         //   GotoNextPoint();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChasePlayer(other.gameObject.transform.position);
        }
    }
}