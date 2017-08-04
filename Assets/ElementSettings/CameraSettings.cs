using System;
using UnityEngine;

public class CameraSettings : MonoBehaviour {
    private GameObject player;
    private Quaternion cameraRotation = Quaternion.Euler(55, 270, 0);
    private Vector3 positionOffset = new Vector3(5, 8, 0);
    private Vector3 oldPosition;

    private void Start() {
        oldPosition = positionOffset;
        transform.SetPositionAndRotation(positionOffset, cameraRotation);
    }

    private void FixedUpdate() {
        if(player == null)
            player = gameObject.scene.FindPlayer();
        if(player != null) {
            var newPosition = player.transform.position + positionOffset;
            transform.Translate((newPosition - oldPosition), Space.World);
            oldPosition = transform.position;
        }
    }
}
