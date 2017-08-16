using System;
using UnityEngine;

public class BomberAbility : MonoBehaviour  {
    public Int32 maxCountBomb = 1;
    protected Int32 bombCounter = 0;
    public Int32 bangDistance = 1;

    private void Update() {
        OnUpdate();
    }

    protected virtual void OnUpdate() {
        if(!Input.GetKeyDown(KeyCode.Space))
            return;
        if(!BombsAreAvailable() || ExistBarrier())
            return;
        var animator = GetComponent<Animator>();
        if(animator != null)
            animator.SetTrigger("StartPlantedBomb");
        PlantBomb(CreateBomb());
        //animator.ResetTrigger("StartPlantedBomb");
    }

    protected virtual void DetonateBomb() {
        bombCounter--;
    }
    protected virtual void PlantBomb(GameObject bomb) {
        bombCounter++;
    }

    protected GameObject CreateBomb() {
        var position = gameObject.GetIntegerPosition();
        var cellForBomb = new Cell((Int32)position.x, (Int32)position.z);
        return new Bomb(cellForBomb, bangDistance, 2, 1) {
            ActionAfterDeath = DetonateBomb,
            BangController = new BangController()
        }.Create();
    }

    private Boolean BombsAreAvailable() {
        return maxCountBomb > 0 && bombCounter < maxCountBomb;
    }
    private Boolean IsBreakCubeOrBomb(Collider other) {
        return other.gameObject.GetParent().OneFrom(BreakCube.tag, Bomb.tag);
    }

    private Boolean ExistBarrier() {
        var position = gameObject.GetIntegerPosition().Set(Coordinate.Y, 1);
        var hitObjects = new PlaneRay(position, new Vector3(0, 0, 0.45f), Vector3.forward) { Distance = 0.9f }.Cast();
        foreach(var hitElement in hitObjects) {
            var hitObject = hitElement.transform.gameObject.GetParent();
            if(hitObject.OneFrom(BreakCube.tag, Bonus.tag, Enemy.tag))
                return true;
        }
        return false;
    }
}
