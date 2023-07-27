using Assets.SRC.ProceduralMapGeneration.Assets.SRC.PlayerControl.Mono;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Assets.SRC.Shared.Utilities;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Assets.SRC.Shared.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    PlayerControlActions playerControlActions;
    Vector3 movement = Vector3.zero;
    VectorMath vMath = new VectorMath();
    private void Awake()
    {
        playerControlActions = new PlayerControlActions();
    }
    private void OnEnable()
    {
        playerControlActions.Enable();
        playerControlActions.PlayerInput.Movement.performed += OnMovementPerformed;
        playerControlActions.PlayerInput.Movement.canceled += OnMovementCanceled;
    }
    private void OnDisable()
    {
        playerControlActions.Disable();
        playerControlActions.PlayerInput.Movement.performed -= OnMovementPerformed;
        playerControlActions.PlayerInput.Movement.canceled -= OnMovementCanceled;
    }

    private void FixedUpdate()
    {
        Debug.Log(movement);
    }
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        movement= vMath.ConvertV2ToV3(value.ReadValue<Vector2>(), VectorMathConvertionEnum.XY_ZXY);
    }
    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        movement = Vector3.zero;
    }
}
