using System;
using UnityEngine;

public class PlayerMoving : BaseMovingAbilityWithWallpass {
    private CharacterController characterController;

    protected override void OnStart() {
        base.OnStart();
        characterController = GetComponent<CharacterController>();
    }

    protected override void OnUpdate() {
        base.OnUpdate();
        Single deltaX = -Input.GetAxis("Vertical") * movingSpeed;
        Single deltaZ = Input.GetAxis("Horizontal") * movingSpeed;
        var movement = new Vector3(deltaX, 0, deltaZ);
        characterController.SimpleMove(movement);
    }
}