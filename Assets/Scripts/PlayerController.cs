using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector2 deltaLook;
    private float xRotation;
    public float xRotateReturn() { return xRotation; }
    private Vector2 moveDirection;
    [SerializeField] private Transform cam;
    [SerializeField] private float lookSpeed;
    private float ySpeed;
    private bool hasJump;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Interface _interface;
    [SerializeField] AudioManager audioManager;
    [SerializeField] Respaw respaw;
    private float jumpforceaccumulate = 0;
    [SerializeField] private float jumpforce = 20;
    [SerializeField] private float minLookAngle;
    [SerializeField] private float maxLookAngle;
    [SerializeField] private CharacterController _characterController;
    private Vector2 deltalookmove = Vector2.zero;
    public Vector2 DeltaLookMoveReturn() { return deltalookmove; }
    [SerializeField] private Camera _camera;
    public PhotonView view;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            view = GetComponent<PhotonView>();
            if (!view.IsMine)
            {
                _camera.enabled = false;
            }
        }


        Cursor.lockState = CursorLockMode.Locked;

    }

    //get the inputs
    public void Look(InputAction.CallbackContext callback)
    {
        deltaLook = callback.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext callback)
    {
        if (callback.performed)
            hasJump = true;
        else
            hasJump = false;
    }

    public void Move(InputAction.CallbackContext callback)
    {
        moveDirection = callback.ReadValue<Vector2>();
    }
    

    //teleport at respawn / checkpoint
    public void goToSPawn(bool death)
    {
        if (SceneManager.GetActiveScene().name == "SampleSceneSolo" || view.IsMine)
        {
            _characterController.enabled = false;
            transform.position = respaw.ReturnCurrentCheckpoint();
            _characterController.enabled = true;
            if (death)
                _interface.CompterDeath();

        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleSceneSolo" || view.IsMine)
        {
            //gravity
            ySpeed += Physics.gravity.y * Time.deltaTime * 4;
            if (_characterController.isGrounded)
            {
                ySpeed = -.5f;
                //jump
                if (hasJump)
                {
                    jumpforceaccumulate += jumpforce * Time.deltaTime;
                    jumpforceaccumulate = Mathf.Clamp(jumpforceaccumulate, 0, 50);
                    _interface.jumpBarre(jumpforceaccumulate / 50);
                }

                else if (jumpforceaccumulate > 0)
                {
                    ySpeed = jumpforceaccumulate;
                    jumpforceaccumulate = 0;
                    _interface.jumpBarre(jumpforceaccumulate / 50);
                    audioManager.PlayAudioClip("Jump sound", false);
                }
            }

            //look + apply gravity
            deltalookmove += deltaLook;
            deltalookmove = new Vector2(Mathf.Clamp(deltalookmove.x, -30, 30), Mathf.Clamp(deltalookmove.y, -30, 30));
            _characterController.Move(transform.TransformDirection(new Vector3(deltalookmove.x, ySpeed, deltalookmove.y)) * moveSpeed * Time.deltaTime);

            //move y
            transform.Rotate(0f, moveDirection.x * lookSpeed, 0f);
            xRotation += moveDirection.y * lookSpeed;

            //clamp + move x
            xRotation = Mathf.Clamp(xRotation, minLookAngle, maxLookAngle);
            cam.localEulerAngles = new Vector3(-xRotation, 0f, 0f);
        }

    }
}
