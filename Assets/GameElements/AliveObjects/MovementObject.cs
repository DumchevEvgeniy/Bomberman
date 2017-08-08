using System;
using UnityEngine;

public abstract class MovementObject : DynamicGameObject {
    public Single RotationSpeed { get; set; }
    public Single MovementSpeed { get; set; }
    public Boolean Wallpass { get; set; }

    public override GameObject CreateGameObject() {
        var movementObject =  base.CreateGameObject();
        InitializeSettings(movementObject);
        return movementObject;
    }

    public virtual void InitializeSettings(GameObject currentObject) { }
}