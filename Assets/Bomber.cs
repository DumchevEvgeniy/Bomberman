using System;
using UnityEngine;

public class Bomber : MonoBehaviour {
    PlayerSettings playerSetting;

    private void Start() {
        playerSetting = GetComponent<PlayerSettings>();
    }

    private void Update() {
        if(!Input.GetKey(KeyCode.Space))
            return;
        if(!playerSetting.ExistBomb())
            return;
        var indexRow = (Int32)Math.Round(gameObject.transform.position.x);
        var indexColumn = (Int32)Math.Round(gameObject.transform.position.z);
        var cellForBomb = new Cell(indexRow, indexColumn);
        if(playerSetting.BombStandsOnThePosition(cellForBomb))
            return;
        new Bomb(cellForBomb).CreateGameObject();
        playerSetting.RemoveBomb(cellForBomb);
    }

}
