using System;
using UnityEngine;

public abstract class MovementObjectSettings : MonoBehaviour {
    public Single movementSpeed;
    public Single rotationSpeed;
    public Boolean wallpass;
    private Boolean alive;

    private void Start() {
        alive = true;
    }

    public void InitializeMovingSettings(Single movementSpeed, Single rotationSpeed, Boolean wallpass) {
        this.movementSpeed = movementSpeed;
        this.rotationSpeed = rotationSpeed;
        this.wallpass = wallpass;
    }

    public Boolean IsAlive() {
        return alive;
    }
    public virtual void Die() {
        alive = false;
    }
}