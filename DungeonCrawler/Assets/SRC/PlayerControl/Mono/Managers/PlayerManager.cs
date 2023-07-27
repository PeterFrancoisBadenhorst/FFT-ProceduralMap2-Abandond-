using Assets.SRC.ProceduralMapGeneration.Assets.SRC.PlayerControl.Mono;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Assets.SRC.Shared.Utilities;
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Shared.Assets.SRC.Shared.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Codice.Client.BaseCommands.Import.Commit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class PlayerManager : MonoBehaviour
{
    [Range(0, 100)]
    public float SpeedMultiplier;

    PlayerControlActions playerControlActions;
    Vector3 movement = Vector3.zero;
    VectorMath vMath = new VectorMath();
    Rigidbody thisBody;
    float modified = 0;

    private void Awake()
    {
        playerControlActions = new PlayerControlActions();
        thisBody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        playerControlActions.Enable();
        playerControlActions.PlayerInput.Modifier.performed += OnModifiedMovementPerformed;
        playerControlActions.PlayerInput.Movement.performed += OnMovementPerformed;
        playerControlActions.PlayerInput.Movement.canceled += OnMovementCanceled;
    }
    private void OnDisable()
    {
        playerControlActions.Disable();
        playerControlActions.PlayerInput.Modifier.performed -= OnModifiedMovementPerformed;
        playerControlActions.PlayerInput.Movement.performed -= OnMovementPerformed;
        playerControlActions.PlayerInput.Movement.canceled -= OnMovementCanceled;
    }
    private void FixedUpdate()
    {
        thisBody.velocity = movement * Time.deltaTime * SpeedMultiplier * 10;
    }
    private void OnModifiedMovementPerformed(InputAction.CallbackContext value)
    {
        modified = value.ReadValue<float>();
    }
    private void OnModifiedMovementCanceled(InputAction.CallbackContext value)
    {
        modified = 0;
    }
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        movement = vMath.ConvertV2ToV3(value.ReadValue<Vector2>(), VectorMathConvertionEnum.XY_XZY);
        if (modified > 0) movement = (movement * .5f) + movement;
    }
    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        movement = Vector3.zero;
    }
}
