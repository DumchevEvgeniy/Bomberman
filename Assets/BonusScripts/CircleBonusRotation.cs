using UnityEngine;

public class CircleBonusRotation : BaseBonusRotation {
    public Vector3 stepAngle = new Vector3(0, 0, 0);

    public override void Rotate() {
        transform.Rotate(stepAngle * speed * Time.deltaTime);
    }
}
