using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBangController {
    public virtual List<String> GetStoppedTags() {
        return new List<String>();
    }
    public abstract void ActionWithAttackedObjects(GameObject gameObject);
}