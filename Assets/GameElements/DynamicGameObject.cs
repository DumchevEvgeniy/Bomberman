using System;
using UnityEngine;

public abstract class DynamicGameObject {
    protected abstract String GetPrefabName();

    public GameObject ToGameObject() {
        return Resources.Load<GameObject>(GetPrefabName());
    }

    public virtual GameObject CreateGameObject() {
        return GameObject.Instantiate<GameObject>(ToGameObject());
    }

    public Boolean IsDerived(System.Object obj) {
        if(obj == null)
            return false;
        return IsDerived(obj.GetType());
    }
    public Boolean IsDerived(Type objType) {
        if(objType == null)
            return false;
        var type = GetType();
        while(type != null) {
            if(objType == type)
                return true;
            type = type.BaseType;
        }
        return false;
    }

    public override Boolean Equals(System.Object obj) {
        if(obj == null)
            return false;
        return GetType() == obj.GetType();
    }
    public override Int32 GetHashCode() {
        return base.GetHashCode();
    }
}