using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDeath : MonoBehaviour {
    public void Start() {
        StartCoroutine(Die());
    }

    private IEnumerator Die() {
        yield return new WaitForSeconds(2.0f);
        var player = FindPlayer();
        var indexRow = (Int32)Math.Round(gameObject.transform.position.x);
        var indexColumn = (Int32)Math.Round(gameObject.transform.position.z);
        var cellForBomb = new Cell(indexRow, indexColumn);

        Destroy(gameObject);

        if(player != null) {
            var playerSetting = player.GetComponent<PlayerSettings>();
            playerSetting.AddBomb(cellForBomb);
        }
    }

    private GameObject FindPlayer() {
        foreach(var obj in gameObject.scene.GetRootGameObjects())
            if(obj.tag == Player.Tag)
                return obj;
        return null;
    }
}