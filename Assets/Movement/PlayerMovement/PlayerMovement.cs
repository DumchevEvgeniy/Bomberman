using System;
using UnityEngine;

public class PlayerMovement : BasePlayerMovement {
    protected override void OnUpdate() {
        base.OnUpdate();
        Single deltaX = -Input.GetAxis("Vertical") * movementSpeed;
        Single deltaZ = Input.GetAxis("Horizontal") * movementSpeed;
        var movement = new Vector3(deltaX, 0, deltaZ);
        characterController.SimpleMove(movement);
    }
}