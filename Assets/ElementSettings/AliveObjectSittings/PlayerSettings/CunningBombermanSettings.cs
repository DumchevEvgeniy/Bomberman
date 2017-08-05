using System;

public class CunningBombermanSettings : BombermanSettings {
    public Boolean preDetonatePossible = false;
    private CunningBomberAbility cunningBomberAbility;

    protected override void OnStart() {
        base.OnStart();
        cunningBomberAbility = GetComponent<CunningBomberAbility>();
    }

    protected override void OnUpdate() {
        base.OnUpdate();
        if(cunningBomberAbility == null)
            return;
        cunningBomberAbility.enable = preDetonatePossible;
    }
}