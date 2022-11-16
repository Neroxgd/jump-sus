using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRender : MonoBehaviour
{
    [SerializeField] private float _FieldofView;
    [SerializeField] private Camera cam;
    [SerializeField] private JambeWalk _jambeWalk;

    void Update()
    {
        cam.fieldOfView = Mathf.Clamp(Mathf.Abs(_jambeWalk.ReturnSpeedWalk())*5, 35, 160);
    }
}
