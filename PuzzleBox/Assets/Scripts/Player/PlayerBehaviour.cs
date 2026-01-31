using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{ 
    LookState = 0,
    PuzzleState = 1
}

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private float yRotationLimit = 88f;

    [SerializeField] private InputReader inputReader;
    [SerializeField] private GameObject target;

    [SerializeField] private PlayerState playerState;

    private bool initialized = false;

    private Camera mainCamera;
    private Vector2 camRot;

    private void Start()
    {
        mainCamera = Camera.main;

        inputReader.SwitchStateEvent += OnStateSwitch;

        UpdatePlayerState(PlayerState.LookState);
    }

    private void OnDestroy()
    {
        inputReader.SwitchStateEvent -= OnStateSwitch;
    }

    // Update is called once per frame
    void Update()
    {
        if(!initialized)
        {
            initialized = true;
            return;
        }

        if(playerState == PlayerState.LookState)
        {
            LookCamUpdate();
        }
        else
        {
            PuzzleCamUpdate();
        }
    }

    void OnStateSwitch(bool state)
    {
        if(!state)
        {
            return;
        }

        UpdatePlayerState((playerState == PlayerState.LookState)  ? PlayerState.PuzzleState : PlayerState.LookState);
    }

    void UpdatePlayerState(PlayerState state)
    {
        if(state == PlayerState.LookState)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            Vector3 euler = mainCamera.transform.localEulerAngles;

            camRot.x = euler.y;
            camRot.y = euler.x > 180 ? euler.x - 360 : euler.x;
        }
        else if(state == PlayerState.PuzzleState)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        playerState = state;
    }

    void LookCamUpdate()
    {
        camRot.x += Mouse.current.delta.x.ReadValue() * sensitivity * Time.deltaTime;
        camRot.y -= Mouse.current.delta.y.ReadValue() * sensitivity * Time.deltaTime;
        camRot.y = Mathf.Clamp(camRot.y, -yRotationLimit, yRotationLimit);

        Quaternion xQuat = Quaternion.AngleAxis(camRot.x, Vector3.up);
        Quaternion yQuat = Quaternion.AngleAxis(camRot.y, Vector3.right);

        mainCamera.transform.localRotation = xQuat * yQuat;
    }
    void PuzzleCamUpdate()
    {
        Vector3 dir = target.transform.position - mainCamera.transform.position;
        Quaternion targetRot = Quaternion.LookRotation(dir);

        float angle = Quaternion.Angle(mainCamera.transform.rotation, targetRot);

        if(angle > 5.0f)
        {
            mainCamera.transform.rotation = Quaternion.RotateTowards(mainCamera.transform.rotation, Quaternion.LookRotation(dir), 1 * Time.deltaTime);
        }
    }
}