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
        if(gameObject.OneFrom(Player.tag, Enemy.tag))
            KillAliveObject(gameObject);
        if(gameObject.CompareTag(BreakCube.tag))
            GameObject.Destroy(gameObject);
        if(gameObject.CompareTag(Bonus.tag))
            KillBonus(gameObject);
    }

    private void KillBonus(GameObject gameObject) {
        var savePosition = gameObject.transform.position;
        GameObject.Destroy(gameObject);
        actionAfterBang += (() => BonusPenalty(savePosition));
    }
    private void BonusPenalty(Vector3 position) {
        Int32 enemyPenaltyCount = 10;
        for(Int32 i = 0; i < enemyPenaltyCount; i++)
            GameFactory.CreateEasyEnemy().Create().transform.position = position;
    }
    private void KillAliveObject(GameObject gameObject) {
        var aliveObjectDeath = gameObject.GetComponent<AliveObjectDeath>();
        if(aliveObjectDeath == null) {
            GameObject.DestroyObject(gameObject);
            return;
        }
        aliveObjectDeath.KillPlayer(() => aliveObjectDeath.PlayAnimationAndDieAfterBang(gameObject));
    }
}