using System;
using UnityEngine;

public class SmoothMovementForEnemy : SmoothMovementBase {
    public SmoothMovementForEnemy(GameObject gameObject)
        : base(gameObject) {
        AddPostAction(PostAction);
    }

    protected override void FrameAction(GameObject gameObject) {
        Direction = gameObject.transform.forward;
        gameObject.transform.Translate(Direction * Distance * MovingStep, Space.World);
    }
    protected void PostAction(GameObject gameObject) {
        var position = gameObject.transform.position;
        gameObject.SetPosition(Coordinate.X, (Int32)Math.Round(position.x))
            .SetPosition(Coordinate.Z, (Int32)Math.Round(position.z));
    }
    protected override Int32 GetNormalCountFrame() {
        return 30;
    }
}
