using System;
using UnityEngine;

public static class PlayerAnimator {
    public const String take = "Take";
    public const String deathAfterBang = "DeathAfterBang";
    public const String death = "Death";
    public const String plantedBomb = "PlantedBomb";
    public const String detonate = "Detonate";
    public const String run = "CanRun";

    public static Boolean PlayRun(GameObject gameObject, Boolean value) {
        return gameObject.ActionWithAnimator(a => a.SetBool(run, value));
    }
    public static Boolean PlayTake(GameObject gameObject) {
        return gameObject.ActionWithAnimator(a => a.SetTrigger(take));
    }
    public static Boolean PlayPlantedBomb(GameObject gameObject) {
        return gameObject.ActionWithAnimator(a => a.SetTrigger(plantedBomb));
    }
    public static Boolean PlayDetonate(GameObject gameObject) {
        return gameObject.ActionWithAnimator(a => a.SetTrigger(detonate));
    }
    public static Boolean PlayDeath(GameObject gameObject) {
        return gameObject.ActionWithAnimator(a => a.SetTrigger(death));
    }
    public static Boolean PlayDeathAfterBang(GameObject gameObject) {
        return gameObject.ActionWithAnimator(a => a.SetTrigger(deathAfterBang));
    }
}
