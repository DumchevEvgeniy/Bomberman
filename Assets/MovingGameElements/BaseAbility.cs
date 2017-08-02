using System;
using UnityEngine;

public abstract class BaseAbility : MonoBehaviour {
    public MovingObjectSettings movingObjectSettings;

    void Start() {
        movingObjectSettings = GetComponent<MovingObjectSettings>();
        if(movingObjectSettings == null)
            return;
        OnStart();
    }

    void Update() {
        if(!movingObjectSettings.IsAlive())
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