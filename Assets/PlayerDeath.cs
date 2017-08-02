using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {
    private SmoothRotation smoothRotating;
    PlayerSettings playerSetting;

    public void Start() {
        playerSetting = GetComponent<PlayerSettings>();
        smoothRotating = new SmoothRotation(gameObject) {
            Distance = -90,
            Direction = new Vector3(1, 0, 0),
            Speed = 50f
        };
        smoothRotating.AddPostAction(g => Die(gameObject));
    }

    public void OnTriggerEnter(Collider other) {
        if(playerSetting == null || !playerSetting.IsAlive())
            return;
        if(other.gameObject.tag == Enemy.Tag && !smoothRotating.Started) {
            smoothRotating.Direction = -other.transform.forward;
            StartCoroutine(smoothRotating.MakeItSmooth());
        }
    }

    private void Die(GameObject gameObject) {
        playerSetting.Die();
        Destroy(gameObject);
    }
}
