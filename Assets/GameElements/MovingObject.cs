using System;

public abstract class MovingObject : DynamicGameObject {
    public Single RotatedSpeed { get; protected set; }
    public Single MovingSpeed { get; protected set; }
    public Boolean Wallpass { get; protected set; }

    public MovingObject(Single movingSpeed, Single rotatedSpeed, Boolean wallpass = false) {
        MovingSpeed = movingSpeed;
        RotatedSpeed = rotatedSpeed;
        Wallpass = wallpass;
    }
}