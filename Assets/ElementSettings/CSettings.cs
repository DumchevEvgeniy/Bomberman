using System;
using UnityEngine;

public class CSettings : MonoBehaviour {
    private GameObject player;
    private Quaternion cameraRotation = Quaternion.Euler(55, 270, 0);
    private Vector3 positionOffset = new Vector3(5, 8, 0);
    private Vector3 oldPosition;
    public Single speed = 1.0f;

    private void Start() {
        oldPosition = positionOffset;
        transform.SetPositionAndRotation(positionOffset, cameraRotation);
    }

    private void FixedUpdate() {
        if(player == null)
            player = FindPlayer();
        if(player != null) {
            var newPosition = player.transform.position + positionOffset;
            transform.Translate((newPosition - oldPosition) /** Time.deltaTime * speed*/, Space.World);
            oldPosition = transform.position;
        }
    }

    private GameObject FindPlayer() {
        foreach(var obj in gameObject.scene.GetRootGameObjects())
            if(obj.tag == Player.Tag)
                return obj;
        return null;
    }
}
