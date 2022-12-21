using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Respaw respaw;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            respaw.SetCurrentCheckpoint(new Vector3(16.4f,92.2f,332.5f));
            playerController.goToSPawn();
        }
    }
}
