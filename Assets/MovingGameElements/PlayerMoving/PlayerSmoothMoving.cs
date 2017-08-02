using System;
using UnityEngine;

public class PlayerSmoothMoving : BaseMovingAbilityWithWallpass {
    private SmoothMovementForPlayer smoothMoving;
    public Single movingDistance = 1f;

    protected override void OnStart() {
        base.OnStart();
        smoothMoving = new SmoothMovementForPlayer(gameObject);
    }

    protected override void OnUpdate() {
        base.OnUpdate();
        if(smoothMoving.Started)
            return;
        var deltaX = Input.GetAxis("Vertical");
        var deltaZ = Input.GetAxis("Horizontal");
        if(deltaX == 0 && deltaZ == 0)
            return;
        Single xDerection = -Math.Sign(deltaX);
        Single zDerection = Math.Sign(deltaZ);
        smoothMoving.Direction = new Vector3(xDerection, 0, zDerection);
        smoothMoving.Distance = movingDistance * GetHypotenuse(deltaX, deltaZ);
        smoothMoving.Speed = movingSpeed;
        StartCoroutine(smoothMoving.MakeItSmooth());
    }

    private Single GetHypotenuse(Single firstCathenus, Single secondCathenus) {
        return (Single)Math.Sqrt(Math.Pow(firstCathenus, 2) + Math.Pow(secondCathenus, 2));
    }
}
