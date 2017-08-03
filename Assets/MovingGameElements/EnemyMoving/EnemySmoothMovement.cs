﻿using System;
using UnityEngine;

public class EnemySmoothMovement : BaseMovementAbilityWithWallpass {
    public Single rangeLook = 1f;
    public Single movementDistance = 1f;
    public Single rotationSpeed = 50f;
    private SmoothMovementForEnemy smoothMovement;
    private SmoothRotation smoothRotation;

    protected override void OnStart() {
        base.OnStart();
        smoothRotation = new SmoothRotation(gameObject) {
            Distance = GetAngle(),
            Speed = rotationSpeed,
            Direction = new Vector3(0, 1, 0)
        };
        smoothMovement = new SmoothMovementForEnemy(gameObject) {
            Distance = movementDistance,
            Speed = movementSpeed,
        };
        smoothMovement.AddPostAction(RotateAfterMoving);
    }

    protected override void OnUpdate() {
        base.OnUpdate();
        if(smoothMovement.Started || smoothRotation.Started)
            return;
        if(CanMove()) {
            StartCoroutine(smoothMovement.MakeItSmooth());
            if(!smoothMovement.Started) {
                smoothRotation.Distance = GetAngle();
                StartCoroutine(smoothRotation.MakeItSmooth());
            }
        }
        else
            StartSmoothRotating();
    }

    private void StartSmoothRotating() {
        smoothRotation.Distance = GetAngle();
        StartCoroutine(smoothRotation.MakeItSmooth());
    }

    private void RotateAfterMoving(GameObject gameObject) {
        if(OnUnevenPosition(gameObject))
            StartSmoothRotating();
    }
    private Boolean OnUnevenPosition(GameObject gameObject) {
        var position = gameObject.transform.position;
        return IsUneven(position.x) && IsUneven(position.z);
    }
    private Boolean IsUneven(Single value) {
        var totalValue = (Int32)value;
        if(totalValue != value)
            return false;
        return totalValue % 2 != 0;
    }

    private Single GetAngle() {
        return new System.Random().Next(-1, 2) * 90;
    }

    private Boolean CanMove() {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(!Physics.Raycast(ray, out hit))
            return false;
        var hitObject = hit.transform.gameObject;
        if(hitObject.tag == Enemy.Tag || hitObject.tag == Player.Tag)
            return true;
        if(wallpass && hitObject.tag == SandCube.Tag)
            return true;
        return hit.distance > rangeLook;
    }
}