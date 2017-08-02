using System;

public abstract class MovementObject : DynamicGameObject {
    public Single RotationSpeed { get; protected set; }
    public Single MovementSpeed { get; protected set; }
    public Boolean Wallpass { get; protected set; }

    public MovementObject(Single movementSpeed, Single rotationSpeed, Boolean wallpass = false) {
        MovementSpeed = movementSpeed;
        RotationSpeed = rotationSpeed;
        Wallpass = wallpass;
    }
}