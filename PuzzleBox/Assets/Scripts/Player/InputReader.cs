using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "New Input", menuName = "Input/InputReader")]
public class InputReader : ScriptableObject, IA_Player.IPlayerInputMapActions
{
    private IA_Player playerInput;

    public event Action<bool> SwitchStateEvent;

    private void OnEnable()
    {
        if(playerInput == null)
        {
            playerInput = new IA_Player();
            playerInput.PlayerInputMap.SetCallbacks(this);
        }

        playerInput.Enable();
    }

    private void OnDisable()
    {
        if (playerInput != null)
        {
            playerInput.Disable();
        }
    }

    public void OnSwitchState(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SwitchStateEvent?.Invoke(true);
        }
        else if (context.canceled)
        {
            SwitchStateEvent?.Invoke(false);
        }
    }
}
