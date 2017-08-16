using System;
using System.Collections;
using UnityEngine;

public class PlayerDeath : PlayerDeathAfterBang {
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
        if(!other.gameObject.CompareTag(Enemy.tag) || !other.gameObject.GetComponent<AliveObjectSettings>().IsAlive())
            return;
        KillPlayer(() => PlayAnimationAndDie(other.gameObject));
    }

    private IEnumerator PlayAnimationAndDie(GameObject other) {
        started = true;
        if(PlayerAnimator.PlayDeath(gameObject)) {
            var enemyMovement = other.GetComponent<EnemyWithSmoothMovementBase>();
            enemyMovement.enable = false;
            EnemyAnimator.PlayKillPlayer(other.gameObject);
            playerSettings.Die();
            yield return new WaitForSeconds(6f);
            EnemyAnimator.PlayRun(other.gameObject);
            enemyMovement.enable = true;
            Destroy(gameObject);
        }
        else
            DieByDefault(-other.transform.forward);
        started = false;
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
