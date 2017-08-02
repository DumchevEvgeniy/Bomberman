using System;

public abstract class BaseMovementAbilityWithWallpass : BaseMovementAbility {
    public Boolean wallpass;

    protected override void OnStart() {
        base.OnStart();
        wallpass = movementObjectSettings.wallpass;
    }
}