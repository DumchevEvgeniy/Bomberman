using UnityEngine;

public abstract class BasePlayerMovement : BaseMovementAbility {
    protected CharacterController characterController;

    protected override void OnStart() {
        base.OnStart();
        characterController = GetComponent<CharacterController>();
    }

    protected override void OnUpdate() {
        base.OnUpdate();
        if(characterController == null)
            return;
    }
}