using System;

public abstract class BaseMovementAbility : BaseAbility {
    protected Single movementSpeed;

    protected override void OnStart() {
        base.OnStart();
        this.movementSpeed = movementObjectSettings.movementSpeed;
    }
}
