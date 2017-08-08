using System;
using System.Collections.Generic;
using UnityEngine;

public class BangController : BaseBangController {
    public override List<String> GetStoppedTags() {
        return new List<String>() {
            ConcreteCube.tag,
            Bonus.tag,
            BreakCube.tag
        };
    }

    public override void ActionWithAttackedObjects(GameObject gameObject) {
        if(gameObject.CompareTag(Enemy.tag))
            GameObject.Destroy(gameObject);
        if(gameObject.CompareTag(Player.tag))
            GameObject.Destroy(gameObject);
        if(gameObject.CompareTag(BreakCube.tag))
            GameObject.Destroy(gameObject);
        if(gameObject.CompareTag(Bonus.tag))
            KillBonus(gameObject);
    }

    private void KillBonus(GameObject gameObject) {
        var savePosition = gameObject.transform.position;
        GameObject.Destroy(gameObject);
        Int32 enemyPenaltyCount = 10;
        for(Int32 i = 0; i < enemyPenaltyCount; i++) {
            var enemy = new Enemy("Enemy", 100, 3, 3, true).CreateGameObject();
            enemy.transform.position = savePosition;
        }
    }
}