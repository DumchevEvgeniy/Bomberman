using System;
using UnityEngine;

public class EnemySmoothMoving : BaseMovingAbilityWithWallpass {
    public Single rangeLook = 1f;
    public Single movingDistance = 1f;
    public Single rotatingSpeed = 50f;
    private SmoothMovementForEnemy smoothMoving;
    private SmoothRotation smoothRotating;

    protected override void OnStart() {
        base.OnStart();
        smoothRotating = new SmoothRotation(gameObject) {
            Distance = GetAngle(),
            Speed = rotatingSpeed,
            Direction = new Vector3(0, 1, 0)
        };
        smoothMoving = new SmoothMovementForEnemy(gameObject) {
            Distance = movingDistance,
            Speed = movingSpeed,
        };
        smoothMoving.AddPostAction(RotateAfterMoving);
    }

    protected override void OnUpdate() {
        base.OnUpdate();
        if(smoothMoving.Started || smoothRotating.Started)
            return;
        if(CanMove()) {

            StartCoroutine(smoothMoving.MakeItSmooth());
            if(!smoothMoving.Started) {
                smoothRotating.Distance = GetAngle();
                StartCoroutine(smoothRotating.MakeItSmooth());
            }
        }
        else
            StartSmoothRotating();
    }

    private void StartSmoothRotating() {
        smoothRotating.Distance = GetAngle();
        StartCoroutine(smoothRotating.MakeItSmooth());
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