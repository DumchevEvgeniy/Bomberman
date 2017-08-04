using System;
using UnityEngine;

public abstract class BaseMovementAbility : MonoBehaviour {
    public Boolean Alive { get; set; }
    public Single movementSpeed = 1.0f;
    public Single rotationSpeed = 1.0f;
    public Boolean wallpass = false;

    void Start() {
        Alive = true;
        OnStart();
    }

    void Update() {
        if(Alive)
            OnUpdate();
    }

    protected virtual void OnStart() {
        return;
    }

    protected virtual void OnUpdate() {
        return;
    }
}