using System;
using UnityEngine;

public abstract class MovingObjectSettings : MonoBehaviour {
    public Single movingSpeed;
    public Single rotatingSpeed;
    public Boolean wallpass;
    private Boolean alive;

    private void Start() {
        alive = true;
    }

    public void InitializeMovingSettings(Single movingSpeed, Single rotatingSpeed, Boolean wallpass) {
        this.movingSpeed = movingSpeed;
        this.rotatingSpeed = rotatingSpeed;
        this.wallpass = wallpass;
    }

    public Boolean IsAlive() {
        return alive;
    }
    public virtual void Die() {
        alive = false;
    }
}