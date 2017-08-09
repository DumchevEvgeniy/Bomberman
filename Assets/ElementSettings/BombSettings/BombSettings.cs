using System;
using System.Collections;
using UnityEngine;

public class BombSettings : MonoBehaviour {
    public Int32 distance = 1;
    public Single timeOfDeath = 2.0f;
    public Single bangLifeTime = 2.0f;
    private Action actionAfterDeath = null;
    private BoxCollider boxCollider;
    public BaseBangController bangController;

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
        MakeABang();
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

    private void MakeABang() {
        var bang = new Bang((Int32)Math.Round(transform.position.x), (Int32)Math.Round(transform.position.z))
            .Create();
        var bangSettings = bang.GetComponent<BangSettings>();
        bangSettings.distance = distance;
        bangSettings.lifeTime = bangLifeTime;
        if(bangController == null)
            return;
        bangSettings.stoppedTags = bangController.GetStoppedTags();
        bangSettings.AddActionWithAttackedObjects(bangController.ActionWithAttackedObjects);
        bangSettings.AddActionAfterBang(bangController.ActionAfterBang);
    }
}