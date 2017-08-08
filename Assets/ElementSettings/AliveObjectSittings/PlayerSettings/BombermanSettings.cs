using System;

public class BombermanSettings : PlayerSettings {
    private const Int32 defaultCountBomb = 1;
    private const Int32 defaultBangDistance = 1;
    private BomberAbility bomberAbility;
    public Int32 maxCountBomb = defaultCountBomb;
    public Int32 bangDistance = defaultBangDistance;

    protected override void OnStart() {
        base.OnStart();
        bomberAbility = GetComponent<BomberAbility>();
        if(bomberAbility == null)
            return;
        bomberAbility.maxCountBomb = maxCountBomb;
        bomberAbility.bangDistance = bangDistance;
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
    public void AddBangDistance() {
        bangDistance++;
        bomberAbility.bangDistance = bangDistance;
    }
    public void ResetBombCount() {
        maxCountBomb = defaultCountBomb;
        bomberAbility.maxCountBomb = defaultCountBomb;
    }
    public void ResetBangDistance() {
        bangDistance = defaultBangDistance;
        bomberAbility.bangDistance = defaultBangDistance;
    }
}