using System;
using System.Collections;
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

    public void NearToPlayer(Single time) {
        if(player == null)
            return;
        StartCoroutine(Near(time));
    }
    private IEnumerator Near(Single time) {
        var oldPositionOddset = positionOffset; 
        positionOffset = new Vector3(1, 2, 0);
        yield return new WaitForSeconds(time);
        positionOffset = oldPositionOddset;
    }
}
