using System;
using System.Collections;
using UnityEngine;

public class TextSettings : MonoBehaviour {
    public Single lifeTime = 1.0f;

    private void Start() {
        StartCoroutine(ShowAndDie());
    }

    public IEnumerator ShowAndDie() {
        var step = new Vector3(0, 0.5f, 0);
        gameObject.transform.Translate(step);
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }
}
