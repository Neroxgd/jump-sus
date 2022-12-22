using UnityEngine;

//teleporte at the end of the game
public class EndGame : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Respaw respaw;
    [SerializeField] private GameObject laser;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            respaw.SetCurrentCheckpoint(new Vector3(16.4f,92.2f,332.5f));
            playerController.goToSPawn(false);
            laser.SetActive(false);
            audioManager.PlayAudioClip("Victory Sound", false);
        }
    }
}
