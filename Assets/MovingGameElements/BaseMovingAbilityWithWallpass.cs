using System;

public abstract class BaseMovingAbilityWithWallpass : BaseMovingAbility {
    public Boolean wallpass;

    protected override void OnStart() {
        base.OnStart();
        wallpass = movingObjectSettings.wallpass;
    }
}