using UnityEngine;

//vision effect when you run
public class CamRender : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private JambeWalk _jambeWalk;

    void Update()
    {
        cam.fieldOfView = Mathf.Clamp(Mathf.Abs(_jambeWalk.ReturnSpeedWalk())*5, 45, 160);
    }
}
