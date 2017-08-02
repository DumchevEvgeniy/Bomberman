using System;

public abstract class BaseMovingAbility : BaseAbility {
    protected Single movingSpeed;

    protected override void OnStart() {
        base.OnStart();
        this.movingSpeed = movingObjectSettings.movingSpeed;
    }
}
