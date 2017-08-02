using System;

public abstract class BaseRotatingAbility : BaseAbility {
    protected Single rotatingSpeed;

    protected override void OnStart() {
        base.OnStart();
        this.rotatingSpeed = movingObjectSettings.rotatingSpeed;
    }
}
