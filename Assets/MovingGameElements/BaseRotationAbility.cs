using System;

public abstract class BaseRotationAbility : BaseAbility {
    protected Single rotationSpeed;

    protected override void OnStart() {
        base.OnStart();
        this.rotationSpeed = movementObjectSettings.rotationSpeed;
    }
}
