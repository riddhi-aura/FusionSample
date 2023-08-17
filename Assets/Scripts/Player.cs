using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Player : NetworkBehaviour
{
    [SerializeField]
    private float Speed = 5f;

    private NetworkCharacterControllerPrototype _characterController = null;

    private void Awake()
    {
        _characterController = GetComponent<NetworkCharacterControllerPrototype>();
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData inputData))
        {
            inputData.MovingDirection.Normalize();
            _characterController.Move(Speed * inputData.MovingDirection * Runner.DeltaTime);
        } 
    }
}
