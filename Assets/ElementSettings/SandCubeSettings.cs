using System;
using UnityEngine;

class SandCubeSettings : MonoBehaviour {
    public Boolean playerWallpass = false;
    private BoxCollider boxCollider = null;

    private void Update() {
        if(playerWallpass && BoxColliderIsActive())
            RemoveBoxCollider();
        if(!playerWallpass && !BoxColliderIsActive())
            AddBoxCollider();
    }

    private void AddBoxCollider() {
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(1, 1, 1);
    }
    private void RemoveBoxCollider() {
        boxCollider.isTrigger = true;
    }
    private Boolean BoxColliderIsActive() {
        return boxCollider != null;
    }
}