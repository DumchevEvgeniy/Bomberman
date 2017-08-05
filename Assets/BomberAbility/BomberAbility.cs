using System;
using UnityEngine;

public class BomberAbility : MonoBehaviour  {
    public Int32 maxCountBomb = 1;
    protected Int32 bombCounter = 0;
    private Boolean existObstacle = false;

    public Single radius = 1;

    private void Update() {
        OnUpdate();
    }

    protected virtual void OnUpdate() {
        if(!Input.GetKey(KeyCode.Space))
            return;
        if(!BombsAreAvailable() || existObstacle)
            return;
        PlantBomb(CreateBomb());
    }

    private void OnTriggerEnter(Collider other) {
        if(IsBreakCubeOrBomb(other))
            existObstacle = true;
    }
    private void OnTriggerExit(Collider other) {
        if(IsBreakCubeOrBomb(other))
            existObstacle = false;
    }

    protected virtual void DetonateBomb() {
        bombCounter--;
    }
    protected virtual void PlantBomb(GameObject bomb) {
        bombCounter++;
    }

    protected GameObject CreateBomb() {
        var indexRow = (Int32)Math.Round(gameObject.transform.position.x);
        var indexColumn = (Int32)Math.Round(gameObject.transform.position.z);
        var cellForBomb = new Cell(indexRow, indexColumn);
        var bomb = new Bomb(cellForBomb).CreateGameObject();
        var bombSettings = bomb.GetComponent<BombSettings>();
        bombSettings.radius = radius;
        bombSettings.AddActionAfterDeath(DetonateBomb);
        return bomb;
    }

    private Boolean BombsAreAvailable() {
        return maxCountBomb > 0 && bombCounter < maxCountBomb;
    }
    private Boolean IsBreakCubeOrBomb(Collider other) {
        return other.CompareTag(BreakCube.Tag) || other.CompareTag(Bomb.Tag);
    }
}
