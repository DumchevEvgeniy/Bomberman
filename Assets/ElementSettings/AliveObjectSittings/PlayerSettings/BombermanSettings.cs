using System;

public class BombermanSettings : PlayerSettings {
    private const Int32 defaultCountBomb = 1;
    private const Single defaultRadius = 1.0f;
    private BomberAbility bomberAbility;
    public Int32 maxCountBomb = defaultCountBomb;
    public Single radius = defaultRadius;

    protected override void OnStart() {
        base.OnStart();
        bomberAbility = GetComponent<BomberAbility>();
        if(bomberAbility == null)
            return;
        bomberAbility.maxCountBomb = maxCountBomb;
        bomberAbility.radius = radius;
    }
    protected override void OnUpdate() {
        base.OnUpdate();
        if(bomberAbility == null)
            return;
    }

    public void AddBomb() {
        maxCountBomb++;
        bomberAbility.maxCountBomb = maxCountBomb;
    }
    public void AddRadius() {
        radius++;
        bomberAbility.radius = radius;
    }
    public void ResetBombCount() {
        maxCountBomb = defaultCountBomb;
        bomberAbility.maxCountBomb = defaultCountBomb;
    }
    public void ResetRadius() {
        radius = defaultRadius;
        bomberAbility.radius = defaultRadius;
    }
}