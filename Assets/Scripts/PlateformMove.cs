using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlateformMove : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 10f;
    [SerializeField] Ease easing;
    void Start()
    {
        transform.DOMove(target.position, speed).SetEase(easing).SetLoops(-1, LoopType.Yoyo);
    }
}
