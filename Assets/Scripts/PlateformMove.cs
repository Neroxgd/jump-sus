using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformMove : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 10f;
    private Vector3 spawnpos;
    private Vector3 endpos;
    private bool sideMove = true;
    void Start()
    {
        endpos = target.position;
        spawnpos = transform.position;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
            sideMove = !sideMove;

        target.position = sideMove ? endpos : spawnpos;
    }
}
