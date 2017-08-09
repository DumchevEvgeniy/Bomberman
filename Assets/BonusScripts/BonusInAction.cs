using System;
using System.Linq;
using UnityEngine;

public class BonusInAction : MonoBehaviour {
    public BonusTypes bonusTypes;

    private void OnTriggerEnter(Collider other) {
        if(!other.gameObject.CompareTag(Player.tag) || ExistBarrier())
            return;
        switch(bonusTypes) {
            case BonusTypes.Bombs:
                ActionBonusBombs(other.gameObject);
                break;
            case BonusTypes.Detonator:
                ActionBonusDetonator(other.gameObject);
                break;
            case BonusTypes.Flames:
                ActionBonusFlames(other.gameObject);
                break;
            case BonusTypes.Speed:
                ActionBonusSpeed(other.gameObject);
                break;
            case BonusTypes.Wallpass:
                ActionBonusWallpass(other.gameObject);
                break;
        }
        Destroy(this.gameObject);
    }

    private Boolean ExistBarrier() {
        var bonusPosition = gameObject.transform.position;
        var centerPosition = new Vector3(bonusPosition.x, 1, bonusPosition.z);
        var position = centerPosition - new Vector3(0, 0, 0.45f);
        var hitObjects = new PlaneRay(position, Vector3.forward) { Distance = 0.9f }.Cast();
        foreach(var hitElement in hitObjects) {
            var hitObject = hitElement.transform.gameObject.GetParent();
            if(!hitObject.OneFrom(Player.tag, Bonus.tag))
                return true;
        }
        return false;
    }

    private void ActionBonusBombs(GameObject gameObject) {
        var bombermanSettings = gameObject.GetComponent<BombermanSettings>();
        if(bombermanSettings == null)
            return;
        bombermanSettings.AddBomb();
    }
    private void ActionBonusDetonator(GameObject gameObject) {
        var cunningBombermanSettings = gameObject.GetComponent<CunningBombermanSettings>();
        if(cunningBombermanSettings == null)
            return;
        cunningBombermanSettings.preDetonatePossible = true;
        //var newSnowman = new PlayerWithHand().CreateGameObject();
        //ComponentCopy.PlayerCopy(gameObject, newSnowman);
        //Destroy(gameObject);
    }
    private void ActionBonusFlames(GameObject gameObject) {
        var bombermanSettings = gameObject.GetComponent<BombermanSettings>();
        if(bombermanSettings == null)
            return;
        bombermanSettings.AddBangDistance();
    }
    private void ActionBonusSpeed(GameObject gameObject) {
        var movementSettings = gameObject.GetComponent<MovementObjectSettings>();
        if(movementSettings == null)
            return;
        movementSettings.movementSpeed++;
        var text = new DynamicGameObjectCreator("Prefabs/SpeedText").Create();
        text.transform.position = gameObject.transform.position;
    }
    private void ActionBonusWallpass(GameObject gameObject) {
        var wallpassSettings = gameObject.GetComponent<WallpassPlayerSettings>();
        if(wallpassSettings == null)
            return;
        wallpassSettings.wallpass = true;
        var camera = gameObject.scene.GetAllElementsByTag("MainCamera").First();
        camera.GetComponent<CameraSettings>().NearToPlayer(1.0f);
    }
}