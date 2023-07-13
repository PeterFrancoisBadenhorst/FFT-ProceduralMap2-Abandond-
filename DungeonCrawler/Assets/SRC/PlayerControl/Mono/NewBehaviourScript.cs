
using Assets.SRC.ProceduralMapGeneration.Assets.SRC.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    private PlayerControlActions input = null;

    private void Awake()
    {
        input = new PlayerControlActions();
    }
    private void OnEnable()
    {
      
    }
    private void OnDisable()
    {
       
    }
    private void OnMovementPerformed()
    {

    }
}
