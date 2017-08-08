using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {
    private SmoothRotation smoothRotation;
    PlayerSettings playerSetting;

    public void Start() {
        playerSetting = GetComponent<PlayerSettings>();
        smoothRotation = new SmoothRotation(gameObject) {
            Distance = -90,
            Direction = new Vector3(1, 0, 0),
            Speed = 50f
        };
        smoothRotation.AddPostAction(g => Die(gameObject));
    }

    public void OnTriggerEnter(Collider other) {
        if(playerSetting == null || !playerSetting.IsAlive())
            return;
        if(other.gameObject.tag == Enemy.tag && !smoothRotation.Started) {
            smoothRotation.Direction = -other.transform.forward;
            StartCoroutine(smoothRotation.MakeItSmooth());
        }
    }

    private void Die(GameObject gameObject) {
        playerSetting.Die();
        Destroy(gameObject);
    }
}
