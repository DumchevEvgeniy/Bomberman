using UnityEngine;

public abstract class BasePlayerMovement : BaseMovementAbility {
    protected CharacterController characterController;
    protected Animator animator;

    protected override void OnStart() {
        base.OnStart();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    protected override void OnUpdate() {
        base.OnUpdate();
        if(characterController == null)
            return;
    }
}