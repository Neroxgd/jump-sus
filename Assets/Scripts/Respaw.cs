using UnityEngine;

public class Respaw : MonoBehaviour
{
    [SerializeField] private Transform spawn1;
    [SerializeField] private Transform player;
    private Vector3 CurrentCheckPoint;
    [SerializeField] private Interface _interface;

    void Start()
    {
        CurrentCheckPoint = spawn1.position;
    }

    //set checkpoints
    void LateUpdate()
    {
        if (player.position.y < -20)
        {
            player.position = CurrentCheckPoint;
            _interface.CompterDeath();
        }
            
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            CurrentCheckPoint = transform.position;
    }

    public void SetCurrentCheckpoint(Vector3 vector3)
    {
        CurrentCheckPoint = vector3;
    }

    public Vector3 ReturnCurrentCheckpoint()
    {
        return CurrentCheckPoint;
    }
}
