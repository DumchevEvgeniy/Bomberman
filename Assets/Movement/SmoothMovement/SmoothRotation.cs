using System;
using UnityEngine;

public class SmoothRotation : SmoothMovementBase {
    public SmoothRotation(GameObject gameObject)
        : base(gameObject) {
        AddPostAction(PostAction);
    }

    protected override void FrameAction(GameObject gameObject) {
        gameObject.transform.Rotate(Direction * Distance * MovingStep, Space.Self);
    }
    protected void PostAction(GameObject gameObject) {
        var rotation = gameObject.transform.rotation;
        gameObject.transform.rotation = Quaternion.Euler(0, (Int32)Math.Round(rotation.eulerAngles.y), 0);
    }
    protected override Int32 GetNormalCountFrame() {
        return 10;
    }
}
