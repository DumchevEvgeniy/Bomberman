using System;
using System.Collections;
using UnityEngine;

public class BombSettings : MonoBehaviour {
    public Single radius = 1.0f;
    public Single timeOfDeath = 40.0f;
    private Action actionAfterDeath = null;
    BoxCollider boxCollider;

    public void Start() {
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(1, 1, 1);
        boxCollider.isTrigger = true;
        StartCoroutine(Die());
    }

    private IEnumerator Die() {
        yield return new WaitForSeconds(timeOfDeath);
        DetonateABomb();
    }

    public void DetonateABomb() {
        Destroy(gameObject);
        StopCoroutine(Die());
        foreach(var action in actionAfterDeath.GetInvocationList())
            ((Action)action)();
    }
    public void AddActionAfterDeath(Action action) {
        actionAfterDeath += action;
    }

    private void OnTriggerExit(Collider other) {
        if(other is CharacterController)
            boxCollider.isTrigger = false;
    }
}