using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respaw : MonoBehaviour
{
    [SerializeField] private Transform spawn1;
    [SerializeField] private Transform spawn2;
    [SerializeField] private Transform spawn3;
    [SerializeField] private Transform player;
    private Vector3 currentCheckPoint;

    void Start()
    {
        currentCheckPoint = spawn1.position;
    }

    void Update()
    {
        if (transform.position.y < -20)
                player.position = currentCheckPoint;
    }
}
