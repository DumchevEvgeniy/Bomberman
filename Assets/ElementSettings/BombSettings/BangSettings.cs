using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangSettings : MonoBehaviour {
    public Int32 distance = 1;
    public Single lifeTime = 1.0f;
    public List<String> stoppedTags = new List<String>();
    private Action actionAfterBang = null;

    private void Start() {
        ForEachBangLine(b => {
            b.distance = distance;
            b.duration = lifeTime;
            b.startPosition = gameObject.transform.position;
            b.stoppedTags = stoppedTags;
        });
        StartCoroutine(StopBang());
    }

    public void AddActionAfterBang(Action action) {
        actionAfterBang += action;
    }

    private IEnumerator StopBang() {        
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
        if(actionAfterBang != null)
            foreach(var action in actionAfterBang.GetInvocationList())
                ((Action)action)();
    }

    public void AddActionWithAttackedObjects(Action<GameObject> action) {
        ForEachBangLine(b => b.AddActionWithAttackedObjects(action));
    }
    private void ForEachBangLine(Action<BangLineSettings> action) {
        foreach(var particleSystem in GetComponentsInChildren<ParticleSystem>()) {
            var bangSettings = particleSystem.GetComponent<BangLineSettings>();
            action(bangSettings);
        }
    }
}
