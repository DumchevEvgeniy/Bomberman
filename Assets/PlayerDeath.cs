using System;
using System.Collections;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {
    private SmoothRotation smoothRotation;
    private PlayerSettings playerSettings;
    private Boolean started = false;

    public void Start() {
        playerSettings = GetComponent<PlayerSettings>();
        smoothRotation = new SmoothRotation(gameObject) {
            Distance = -90,
            Direction = new Vector3(1, 0, 0),
            Speed = 50f
        };
        smoothRotation.AddPostAction(g => Die(gameObject));
    }

    public void OnTriggerEnter(Collider other) {
        if(playerSettings == null || !playerSettings.IsAlive() || started || smoothRotation.Started)
            return;
        if(!other.gameObject.CompareTag(Enemy.tag))
            return;
        KillPlayer(() => PlayAnimationAndDie(other.gameObject));
    }

    private IEnumerator PlayAnimationAndDie(GameObject other) {
        started = true;
        if(PlayerAnimator.PlayDeath(gameObject)) {
            playerSettings.Die();
            yield return new WaitForSeconds(6f);
            Destroy(gameObject);
        }
        else
            DieByDefault(-other.transform.forward);
        started = false;
    }

    public IEnumerator PlayAnimationAndDieAfterBang(GameObject gameObject) {
        var playerSettings = gameObject.GetComponent<PlayerSettings>();
        if(PlayerAnimator.PlayDeathAfterBang(gameObject)) {
            playerSettings.Die();
            yield return new WaitForSeconds(6f);
        }
        GameObject.Destroy(gameObject);
    }

    public void KillPlayer(Func<IEnumerator> killFunc) {
        StartCoroutine(killFunc());
    }

    private void DieByDefault(Vector3 direction) {
        smoothRotation.Direction = direction;
        StartCoroutine(smoothRotation.MakeItSmooth());
    }
    private void Die(GameObject gameObject) {
        playerSettings.Die();
        Destroy(gameObject);
    }
}
