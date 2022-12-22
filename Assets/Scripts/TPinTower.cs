using UnityEngine;

//teleporte in the tower
public class TPinTower : MonoBehaviour
{
    [SerializeField] private Respaw respaw;
    [SerializeField] PlayerController playerController;
    [SerializeField] private GameObject laser;
    void OnTriggerEnter(Collider other)
    {
        respaw.SetCurrentCheckpoint(new Vector3(21.3f,21.4f,330.5f));
        playerController.goToSPawn(false);
        laser.SetActive(true);
    }
}
