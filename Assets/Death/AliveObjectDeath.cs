using System;
using System.Collections;
using UnityEngine;

public abstract class AliveObjectDeath : MonoBehaviour {
    private void Start() {
        OnStart();
    }
    private void Update() {
        OnUpdate();
    }

    protected virtual void OnStart() { }
    protected virtual void OnUpdate() { }

    public void KillPlayer(Func<IEnumerator> killFunc) {
        StartCoroutine(killFunc());
    }

    public IEnumerator PlayAnimationAndDieAfterBang(GameObject gameObject) {
        var objectSettings = gameObject.GetComponent<AliveObjectSettings>();
        if(TryPlayAnimation(gameObject)) {
            objectSettings.Die();
            yield return new WaitForSeconds(6f);
        }
        GameObject.Destroy(gameObject);
    }
    protected abstract Boolean TryPlayAnimation(GameObject gameObject);
}
