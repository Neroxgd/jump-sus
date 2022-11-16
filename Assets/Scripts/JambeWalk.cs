using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JambeWalk : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    [SerializeField] Transform Rleg;
    [SerializeField] Transform Lleg;
    [SerializeField] private float leglerp = 0.5f;
    private float speedWalk;
    public float ReturnSpeedWalk(){return speedWalk;}
    private bool directionwalk = true;
    [SerializeField] private float SetSpeedWalk;
    [SerializeField] private Transform parentRotate;

    void Update()
    {
        //move legs
        if (_playerController.DeltaLookMoveReturn() != Vector2.zero)
        {
            Rleg.localRotation = Quaternion.Lerp(Quaternion.Euler(-45, 0, 0), Quaternion.Euler(45, 0, 0), leglerp);
            Lleg.localRotation = Quaternion.Lerp(Quaternion.Euler(-45, 0, 0), Quaternion.Euler(45, 0, 0), Mathf.Abs(leglerp - 1));

            if (_playerController.DeltaLookMoveReturn().x > _playerController.DeltaLookMoveReturn().y)
                speedWalk = Mathf.Abs(_playerController.DeltaLookMoveReturn().x / SetSpeedWalk);
            else
                speedWalk = Mathf.Abs(_playerController.DeltaLookMoveReturn().y / SetSpeedWalk);

            if (leglerp <= .09f)
                directionwalk = !directionwalk;
            else if (leglerp >= .99f)
                directionwalk = !directionwalk;
            

            // if (directionwalk)
            //     speedWalk = -Mathf.Abs(speedWalk);
            // else
            //     speedWalk = Mathf.Abs(speedWalk);

            speedWalk = directionwalk ? -Mathf.Abs(speedWalk) : Mathf.Abs(speedWalk);

            leglerp += speedWalk * Time.deltaTime;
            leglerp = Mathf.Clamp(leglerp, 0, 1);
            if (speedWalk > -.05 && speedWalk< .05)
                leglerp = 0.5f;
        }
    }
}
