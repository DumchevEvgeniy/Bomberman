using System;
using UnityEngine;

public static class EnemyAnimator {
    public const String deathAfterBang = "DeathAfterBang";
    public const String killPlayer = "KillPlayer";
    public const String canRun = "CanRun";

    public static Boolean PlayDeathAfterBang(GameObject gameObject) {
        return gameObject.ActionWithAnimator(a => a.SetTrigger(deathAfterBang));
    }
    public static Boolean PlayKillPlayer(GameObject gameObject) {
        return gameObject.ActionWithAnimator(a => a.SetTrigger(killPlayer));
    }
    public static Boolean PlayRun(GameObject gameObject) {
        return gameObject.ActionWithAnimator(a => a.SetTrigger(canRun));
    }
}
