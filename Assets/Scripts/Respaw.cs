using UnityEngine;

public class Respaw : MonoBehaviour
{
    [SerializeField] private Transform spawn1;
    [SerializeField] private Transform player;
    private Vector3 CurrentCheckPoint;
    [SerializeField] private Interface _interface;
    [SerializeField] private PlayerController playerController;
    [SerializeField] AudioManager audioManager;

    void Start()
    {
        CurrentCheckPoint = spawn1.position;
    }

    //set checkpoints
    void Update()
    {
        //kill if you fall
        if (player.position.y < -20)
        {
            playerController.goToSPawn(true);
            audioManager.PlayAudioClip("Lego Yoda Death", false);
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
