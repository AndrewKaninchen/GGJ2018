using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMoveController : MonoBehaviour
{
    enum States
    {
        Patrol,
        Pursue,
        Drunk
    }

    [SerializeField]
    private BotStatsHolder stats;
    [SerializeField]
    private NavMeshAgent agent;

    private Animator anim;


    private GameObject target;
    private States currentState;

    private float drunkness;

    private void Awake()
    {
        if (!anim) anim = GetComponentInChildren<Animator>();
        if (!agent) agent = GetComponent<NavMeshAgent>();
        if (!stats) stats = GetComponent<BotStatsHolder>();

        agent.speed = stats.moveStats.speed;

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
        if (GameManager.currentPlayerControlledBot == null)
            return;
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
                if (target.gameObject != GameManager.currentPlayerControlledBot)
                { 
                    currentState = States.Patrol;
                    agent.SetDestination(transform.position); //forçada de barra
                    break;
                }
                agent.SetDestination(target.transform.position);
                var movement = agent.desiredVelocity;

                drunkness += Random.Range(0f, 3f) * Time.deltaTime;
                if(drunkness > 5f)
                {
                    agent.SetDestination(RandomNavmeshLocation(drunkness*15f));
                    currentState = States.Drunk;
                }
                break;
            case States.Drunk:
                drunkness -= Random.Range(0f, .3f) * Time.deltaTime;
                if(drunkness < 2f || agent.remainingDistance < .5f)
                {
                    currentState = States.Pursue;
                }
                break;
        }

        if (agent.velocity.sqrMagnitude > Mathf.Epsilon)
            anim.SetBool("Walking", true);
        else
            anim.SetBool("Walking", false);
    }

    private void OnDrawGizmosSelected()
    {
        if (currentState == States.Patrol)
            Gizmos.color = Color.magenta;
        else
            Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stats.genericStats.detectionRadius);
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

}
