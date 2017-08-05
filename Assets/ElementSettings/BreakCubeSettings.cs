using System;
using UnityEngine;

class BreakCubeSettings : MonoBehaviour {
    public Boolean playerWallpass = false;
    private BoxCollider boxCollider = null;

    private void Start() {
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(1, 1, 1);
    }

    private void Update() {
        if(playerWallpass && BoxColliderIsActive())
            boxCollider.isTrigger = true;
        if(!playerWallpass && !BoxColliderIsActive())
            boxCollider.isTrigger = false;
    }

    private Boolean BoxColliderIsActive() {
        return !boxCollider.isTrigger;
    }
}