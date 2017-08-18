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
            KillBreakCube(gameObject);
        if(gameObject.CompareTag(Bonus.tag))
            KillBonus(gameObject);
    }

    private void KillBreakCube(GameObject gameObject) {
        var field = gameObject.scene.GetField();
        if(field != null) {
            var position = gameObject.GetIntegerPosition();
            field.RemoveElement((Int32)position.x, (Int32)position.z, typeof(BreakCube));
        }
        GameObject.Destroy(gameObject);
    }

    private void KillBonus(GameObject gameObject) {
        var savePosition = gameObject.transform.position;
        GameObject.Destroy(gameObject);
        actionAfterBang += (() => BonusPenalty(savePosition));
    }
    private void BonusPenalty(Vector3 position) {
        Int32 enemyPenaltyCount = 10;
        for(Int32 i = 0; i < enemyPenaltyCount; i++)
            GameFactory.CreateEasyEnemy().Create()
                .SetPosition(Coordinate.X, position.x)
                .SetPosition(Coordinate.Z, position.z);
    }
    private void KillAliveObject(GameObject gameObject) {
        if(!gameObject.GetComponent<AliveObjectSettings>().IsAlive())
            return;
        var aliveObjectDeath = gameObject.GetComponent<AliveObjectDeath>();
        if(aliveObjectDeath == null) {
            GameObject.DestroyObject(gameObject);
            return;
        }
        aliveObjectDeath.KillAliveObject(() => aliveObjectDeath.PlayAnimationAndDieAfterBang(gameObject));
    }
}