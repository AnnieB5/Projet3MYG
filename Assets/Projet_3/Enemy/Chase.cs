using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Chase : MonoBehaviour
{
    private SphereCollider visionSphere;
    [SerializeField] private NavMeshAgent agent;
    [HideInInspector] public bool isChasing;

    void Start()
    {
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        //Initialise le drapeau Chase/Patrol comme étant en patrouille au start.
        isChasing = false;

    }

    void Update()
    {
        /*
        if(isChasing == true)
        {
            ChasePlayer(); //pas possible car doit récupérer la position du Player hors OnTriggerEnter
        }
        */
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChasePlayer(other.gameObject.transform.position);

            //Passe le drapeau en mode Chasse activée, Patrouille désactivée
            isChasing = true;
        }
    }

    void ChasePlayer(Vector3 position)
    {
        // Set the agent to go to the currently selected destination.
        agent.destination = position;

        Debug.Log("Chasse activée pour la position" + position);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Passe le drapeau en mode Patrouille activée, Chasse désactivée
            isChasing = false;
            //Debug.Log("Patrouille activée"); //Attention, trop souvent envoyé en console, sera gardée sur la première ligne d'annonce de ce message
        }
    }
}