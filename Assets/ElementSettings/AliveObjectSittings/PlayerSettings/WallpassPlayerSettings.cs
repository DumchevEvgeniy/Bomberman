using System;
using System.Linq;

public class WallpassPlayerSettings : MovementObjectSettings {
    private Boolean oldWallpass = false;

    protected override void OnStart() {
        base.OnStart();
        IndicateWallpassAbility();
    }

    protected override void OnUpdate() {
        base.OnUpdate();
        if(oldWallpass != wallpass)
            IndicateWallpassAbility();
        movementAbilities.ToList().ForEach(ma => ma.wallpass = wallpass);
    }

    private void IndicateWallpassAbility() {
        var breakCubes = gameObject.scene.FindAllBreakCube();
        foreach(var cube in breakCubes) {
            var cubeSetting = cube.GetComponent<BreakCubeSettings>();
            cubeSetting.playerWallpass = wallpass;
        }
        oldWallpass = wallpass;
    }
}
