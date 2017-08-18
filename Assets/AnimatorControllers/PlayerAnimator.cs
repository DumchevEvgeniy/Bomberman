﻿using System;
using UnityEngine;

public static class PlayerAnimator {
    public const String parameterTake = "Take";
    public const String parameterDeathAfterBang = "DeathAfterBang";
    public const String parameterDeath = "Death";
    public const String parameterPlantedBomb = "PlantedBomb";
    public const String parameterDetonate = "Detonate";
    public const String parameterRun = "CanRun";

    public static Boolean PlayRun(GameObject gameObject, Boolean value) {
        return gameObject.ActionWithAnimator(a => a.SetBool(parameterRun, value));
    }
    public static Boolean PlayTake(GameObject gameObject) {
        return gameObject.ActionWithAnimator(a => a.SetTrigger(parameterTake));
    }
    public static Boolean PlayPlantedBomb(GameObject gameObject) {
        return gameObject.ActionWithAnimator(a => a.SetTrigger(parameterPlantedBomb));
    }
    public static Boolean PlayDetonate(GameObject gameObject) {
        return gameObject.ActionWithAnimator(a => a.SetTrigger(parameterDetonate));
    }
    public static Boolean PlayDeath(GameObject gameObject) {
        return gameObject.ActionWithAnimator(a => a.SetTrigger(parameterDeath));
    }
    public static Boolean PlayDeathAfterBang(GameObject gameObject) {
        return gameObject.ActionWithAnimator(a => a.SetTrigger(parameterDeathAfterBang));
    }
}
