﻿using System;
using UnityEngine;

public class PlayerRotate : MonoBehaviour {
    public Single speedRotate = 5.0f;
    private const Int32 circleQuartet = 90;
    private const Int32 circleHalf = 180;
    private const Int32 circleLength = 360;

    void Update() {
        var newPosition = GetNewPosition();
        var oldPosition = transform.rotation.eulerAngles.y;
        var rotation = new Vector3(0, GetRotationCorner(oldPosition, newPosition), 0) * speedRotate * Time.deltaTime;
        transform.Rotate(rotation);
    }

    private Single GetNewPosition() {
        Single verticalOffset = GetOffsetByForceOfPressing(Input.GetAxis("Vertical"));
        Single horizontalOffset = GetOffsetByForceOfPressing(Input.GetAxis("Horizontal"));
        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
            return GetAverage(circleQuartet + horizontalOffset, circleHalf - verticalOffset);
        if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
            return GetAverage(-circleQuartet - horizontalOffset, -circleHalf + verticalOffset);
        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
            return GetAverage(circleQuartet - horizontalOffset, 0 + verticalOffset);
        if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
            return GetAverage(-circleQuartet - horizontalOffset, 0 - verticalOffset);
        if(Input.GetKey(KeyCode.LeftArrow))
            return circleQuartet;
        if(Input.GetKey(KeyCode.RightArrow))
            return -circleQuartet;
        if(Input.GetKey(KeyCode.DownArrow))
            return 0;
        if(Input.GetKey(KeyCode.UpArrow))
            return -circleHalf;
        return transform.rotation.eulerAngles.y;
    }

    private Single GetRotationCorner(Single oldPosition, Single newPosition) {
        var oldPositionOnCircle = ToPositionOnCircel(oldPosition);
        var newPositionOnCircle = ToPositionOnCircel(newPosition);
        var minPath = newPositionOnCircle - oldPositionOnCircle;
        if(Mathf.Abs(minPath) == circleHalf)
            return new System.Random().Next(0, 2) == 0 ? 180 : -180;
        if(minPath < -circleHalf)
            return minPath + circleLength;
        if(minPath > circleHalf)
            return minPath - circleLength;
        return minPath;
    }
    private Single ToPositionOnCircel(Single position) {
        while(position < -180 && position >= 180) {
            if(position < -180)
                position += 360;
            if(position >= 180)
                position -= 380;
        }
        return position;
    }

    private Single GetOffsetByForceOfPressing(Single force) {
        return circleQuartet - Math.Abs(circleQuartet * force);
    }
    private Single GetAverage(Single firstValue, Single secondValue) {
        return (Single)((firstValue + secondValue) / 2.0);
    }
}
