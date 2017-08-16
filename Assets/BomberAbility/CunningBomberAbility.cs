using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CunningBomberAbility : BomberAbility {
    public Boolean enable = true;
    private List<GameObject> mortgagedBombs = new List<GameObject>();

    protected override void OnUpdate() {
        base.OnUpdate();
        if(!enable)
            return;
        if(!Input.GetKeyDown(KeyCode.LeftShift))
            return;
        if(mortgagedBombs.IsEmpty())
            return;
        PlayerAnimator.PlayDetonate(gameObject);
        GetFirstBomb().GetComponent<BombSettings>().DetonateABomb();
    }
    protected override void DetonateBomb() {
        if(!mortgagedBombs.IsEmpty())
            mortgagedBombs.RemoveAt(0);
        base.DetonateBomb();
    }
    protected override void PlantBomb(GameObject bomb) {
        mortgagedBombs.Add(bomb);
        base.PlantBomb(bomb);
    }

    private GameObject GetFirstBomb() {
        return mortgagedBombs.FirstOrDefault();
    }
}
