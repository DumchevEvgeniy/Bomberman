using System;
using UnityEngine;

class SandCubeSettings : MonoBehaviour {
    private BoxCollider boxCollider;

    private void Start() {
        AddBoxCollider();
        //boxCollider.isTrigger = true;
    }

    //private void OnTriggerEnter(Collider other) {
    //    if(IsMovingObject(other.gameObject)) {
    //        var movingObjectSettings = other.gameObject.GetComponent<MovingObjectSettings>();
    //        if(!movingObjectSettings.wallpass) {
    //            AddBoxCollider();
    //        }
    //    }
    //}

    private void AddBoxCollider() {
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(1, 1, 1); 
    }

    private Boolean IsMovingObject(GameObject gameObject) {
        return gameObject.tag == Player.Tag || gameObject.tag == Enemy.Tag;
    }
}