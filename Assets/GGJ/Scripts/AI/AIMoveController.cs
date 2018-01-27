using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMoveController : MonoBehaviour
{
    enum States
    {
        Patrol,
        Pursue
    }

    [SerializeField]
    private BotStatsHolder stats;
    [SerializeField]
    private NavMeshAgent agent;
    
    private GameObject target;
    private States currentState;



    private void Awake()
    {
        // if (!ccontroller) ccontroller = GetComponent<CharacterController>();
        if (!agent) agent = GetComponent<NavMeshAgent>();
        if (!stats) stats = GetComponent<BotStatsHolder>();


    }

    private void OnEnable()
    {
        agent.enabled = true;
    }

    private void OnDisable()
    {
        agent.enabled = false;
    }

    private void Update()
    {
        switch (currentState)
        {
            case States.Patrol:
                if (Vector3.Distance(GameManager.currentPlayerControlledBot.transform.position, transform.position) <= stats.genericStats.detectionRadius)
                {
                    target = GameManager.currentPlayerControlledBot;
                    agent.SetDestination(target.transform.position);
                    currentState = States.Pursue;
                }
                break;
            case States.Pursue:
                agent.SetDestination(target.transform.position);
                var movement = agent.desiredVelocity;
                //ccontroller.SimpleMove(movement);
                //transform.position = agent.nextPosition;
                break;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        if (currentState == States.Patrol)
            Gizmos.color = Color.magenta;
        else
            Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stats.genericStats.detectionRadius);
    }

}
