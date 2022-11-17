using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAMobs : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform posagent;
    private Vector3 randompos;
    [SerializeField] private float minRandomPosX;
    [SerializeField] private float maxRandomPosX;
    [SerializeField] private float minRandomPosY;
    [SerializeField] private float maxRandomPosY;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        posagent = GetComponent<Transform>();
        RandomPos();
        agentGoToPos();
    }
 
    public void agentGoToPos()
    {
        agent.SetDestination(randompos);
    }

    public void RandomPos()
    {
        randompos = new Vector3(Random.Range(minRandomPosX, maxRandomPosX), posagent.position.y, Random.Range(minRandomPosY, maxRandomPosY));
    }
    void Update()
    {
        if (posagent.position == randompos || !agent.hasPath)
        {
            RandomPos();
            agentGoToPos();
        }
    }
}
