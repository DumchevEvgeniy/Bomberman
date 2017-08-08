using System;

public class CunningBombermanSettings : BombermanSettings {
    public Boolean preDetonatePossible = false;

    protected override void AddDefaultBomberAbility() {
        bomberAbility = gameObject.AddComponent<CunningBomberAbility>();
    }

    protected override void OnUpdate() {
        base.OnUpdate();
        var cunningBomberAbility = (bomberAbility as CunningBomberAbility);
        if(cunningBomberAbility != null)
            cunningBomberAbility.enable = preDetonatePossible;
    }
}