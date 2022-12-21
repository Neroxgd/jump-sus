using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respaw : MonoBehaviour
{
    [SerializeField] private Transform spawn1;
    [SerializeField] private Transform player;
    private Vector3 CurrentCheckPoint;

    void Start()
    {
        CurrentCheckPoint = spawn1.position;
    }

    void LateUpdate()
    {
        if (player.position.y < -20)
            player.position = CurrentCheckPoint;
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
