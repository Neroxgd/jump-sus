using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class IAMobs : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform posagent;
    private Vector3 randompos;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private float minRandomPosX;
    [SerializeField] private float maxRandomPosX;
    [SerializeField] private float minRandomPosY;
    [SerializeField] private float maxRandomPosY;
    [SerializeField] private PlayerController _playerController;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        posagent = GetComponent<Transform>();
        RandomPos();
        agentGoToPos();
    }

    //set the random paterne of the mob
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
            StartCoroutine(waitfornewpos());
        }
    }

    //kill the player
    private void OnTriggerEnter(Collider other)
    {
        _playerController = other.GetComponent<PlayerController>();
        if (other.gameObject.CompareTag("Player"))
        {
            _playerController.goToSPawn(true);
            audioManager.PlayAudioClip("Among Us (Kill)", false);
        }
            
    }

    IEnumerator waitfornewpos()
    {
        yield return new WaitForSeconds(3);
        agentGoToPos();
    }
}
