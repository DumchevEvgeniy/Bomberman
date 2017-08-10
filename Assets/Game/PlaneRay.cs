﻿using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class PlaneRay {
    private readonly Vector3 direction;
    private readonly Single halfLengthBox = 0.49f;
    private readonly Vector3 plane;
    private readonly Vector3 startPosition;
    public Single Distance { get; set; }

    public PlaneRay(Vector3 startPosition, Vector3 direction) {
        this.startPosition = startPosition;
        this.direction = direction;
        plane = GetPlane(direction);
    }

    public IEnumerable<RaycastHit> Cast() {
        return Physics.BoxCastAll(startPosition, plane, direction, Quaternion.Euler(0, 0, 0), Distance)
            .OrderBy(el => el.distance);
    }

    private Vector3 GetPlane(Vector3 direction) {
        var positiveDirection = new Vector3(Math.Abs(direction.x), Math.Abs(direction.y), Math.Abs(direction.z));
        return (Vector3.one - positiveDirection) * halfLengthBox;
    }
}