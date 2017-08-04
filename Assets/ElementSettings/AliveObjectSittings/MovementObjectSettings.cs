using System;

public abstract class MovementObjectSettings : AliveObjectSettings {
    public Single movementSpeed = 1;
    public Single rotationSpeed = 2;
    public Boolean wallpass = false;
    protected BaseMovementAbility[] movementAbilities;

    protected override void OnStart() {
        base.OnStart();
        movementAbilities = GetComponents<BaseMovementAbility>();
    }
    
    protected override void OnUpdate() {
        base.OnUpdate();
        if(movementAbilities == null)
            return;
        foreach(var movementAbility in movementAbilities) {
            movementAbility.Alive = alive;
            movementAbility.movementSpeed = movementSpeed;
            movementAbility.rotationSpeed = rotationSpeed;
            movementAbility.wallpass = wallpass;
        }
    }

    public void InitializeMovingSettings(Single movementSpeed, Single rotationSpeed, Boolean wallpass) {
        this.movementSpeed = movementSpeed;
        this.rotationSpeed = rotationSpeed;
        this.wallpass = wallpass;
    }
}