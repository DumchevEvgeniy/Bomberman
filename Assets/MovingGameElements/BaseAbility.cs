using System;
using UnityEngine;

public abstract class BaseAbility : MonoBehaviour {
    public MovementObjectSettings movementObjectSettings;

    void Start() {
        movementObjectSettings = GetComponent<MovementObjectSettings>();
        if(movementObjectSettings == null)
            return;
        OnStart();
    }

    void Update() {
        if(!movementObjectSettings.IsAlive())
            return;
        OnUpdate();
    }

    protected virtual void OnStart() {
        return;
    }

    protected virtual void OnUpdate() {
        return;
    }
}