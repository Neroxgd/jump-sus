using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Lasers : MonoBehaviour
{
    [SerializeField] private Transform laser_RtoL;
    [SerializeField] private Transform laser_LtoR;
    [SerializeField] private Transform laser_FtoB;
    [SerializeField] private Transform laser_BtoF;
    [SerializeField] private PlayerController playerController;
    void Start()
    {
        laser_RtoL.DOMoveX(-20, 10).SetLoops(-1, LoopType.Yoyo);
        laser_LtoR.DOMoveX(90, 10).SetLoops(-1, LoopType.Yoyo);
        laser_FtoB.DOMoveZ(200, 10).SetLoops(-1, LoopType.Yoyo);
        laser_BtoF.DOMoveZ(320, 10).SetLoops(-1, LoopType.Yoyo);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerController.goToSPawn();
    }
}
