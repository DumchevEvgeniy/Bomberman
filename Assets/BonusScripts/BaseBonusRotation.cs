using System;
using UnityEngine;

public abstract class BaseBonusRotation : MonoBehaviour {
    public Single speed = 1.0f;

    private void Update() {
        Rotate();
    }

    public abstract void Rotate();
}
