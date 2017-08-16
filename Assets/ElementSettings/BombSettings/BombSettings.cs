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

    public void Update() {
        if(!boxCollider.isTrigger)
            return;
        var position = gameObject.GetIntegerPosition().Set(Coordinate.Y, 1);
        var hitObjects = new PlaneRay(position, new Vector3(0, 0, 0.49f), Vector3.forward) { Distance = 0.98f }.Cast();
        foreach(var hitElement in hitObjects) {
            var hitObject = hitElement.transform.gameObject.GetParent();
            if(hitObject.CompareTag(Player.tag))
                return;
        }
        boxCollider.isTrigger = false;
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