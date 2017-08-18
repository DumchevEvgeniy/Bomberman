using System;
using UnityEngine;

public static class EnemyAnimator {
    public const String parameterDeathAfterBang = "DeathAfterBang";
    public const String parameterKillPlayer = "KillPlayer";
    public const String parameterCanRun = "CanRun";

    public static Boolean PlayDeathAfterBang(GameObject gameObject) {
        return gameObject.ActionWithAnimator(a => a.SetTrigger(parameterDeathAfterBang));
    }
    public static Boolean PlayKillPlayer(GameObject gameObject) {
        return gameObject.ActionWithAnimator(a => a.SetTrigger(parameterKillPlayer));
    }
    public static Boolean PlayRun(GameObject gameObject) {
        return gameObject.ActionWithAnimator(a => a.SetTrigger(parameterCanRun));
    }
}
