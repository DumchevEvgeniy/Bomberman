using System;
using UnityEngine;

public class BangRay {
    private readonly Vector3 direction;
    private readonly Single halfLengthBox = 0.45f;
    private readonly Vector3 plane;
    private readonly Vector3 startPosition;
    public Single Distance { get; set; }

    public BangRay(Vector3 startPosition, Vector3 direction) {
        this.startPosition = startPosition;
        this.direction = direction;
        plane = GetPlane(direction);
    }

    public RaycastHit[] Cast() {
        return Physics.BoxCastAll(startPosition, plane, direction, Quaternion.Euler(0, 0, 0), Distance);
    }

    private Vector3 GetPlane(Vector3 direction) {
        var xPlane = GetPlaneValue(direction.x);
        var yPlane = GetPlaneValue(direction.y);
        var zPlane = GetPlaneValue(direction.z);
        return new Vector3(xPlane, yPlane, zPlane);
    }
    private Single GetPlaneValue(Single coordinateValue) {
        return coordinateValue == 0 ? halfLengthBox : 0;
    }
}