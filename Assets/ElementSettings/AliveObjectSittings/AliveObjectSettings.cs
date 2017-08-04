using System;
using UnityEngine;

public abstract class AliveObjectSettings : MonoBehaviour {
    protected Boolean alive = true;

    private void Start() {
        alive = true;
        OnStart();
    }
    private void Update() {
        OnUpdate();
    }

    protected virtual void OnStart() {
        return;
    }
    protected virtual void OnUpdate() {
        return;
    }

    public Boolean IsAlive() {
        return alive;
    }
    public virtual void Die() {
        alive = false;
    }
}
