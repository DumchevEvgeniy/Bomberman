using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BangLineSettings : MonoBehaviour {
    public Vector3 direction;
    public Vector3 startPosition;
    public Int32 distance = 1;
    public Single duration = 1.0f;
    public List<String> stoppedTags = new List<String>();
    private Action<GameObject> actionWithAttackedObjects = null;
    private ParticleSystem bang;
    private BangRay bangRay;
    private List<GameObject> hitObjects = new List<GameObject>();
    
    private void Start() {
        bangRay = new BangRay(startPosition, direction) { Distance = distance };
        InitializeDistance();
        bang = GetComponent<ParticleSystem>();
        UpdateBangSettings();
        bang.Simulate(duration);
    }
    private void Update() {
        var currentHitObjects = bangRay.Cast();
        foreach(var hitObj in currentHitObjects) {
            var obj = hitObj.transform.gameObject.GetParent();
            if(hitObjects.Contains(obj))
                continue;
            Callback(obj);
        }
    }

    public void AddActionWithAttackedObjects(Action<GameObject> action) {
        actionWithAttackedObjects += action;
    }

    private void InitializeDistance() {
        var hitObjects = bangRay.Cast();
        if(!ExistStoppedElement(hitObjects))
            return;
        var firstStoppedElement = GetFirstStoppedElement(hitObjects).transform.gameObject.GetParent();
        var distanceBetweenTwoObjects = firstStoppedElement.transform.position - startPosition;
        distance = GetNotZeroCoordinate(distanceBetweenTwoObjects);
        bangRay.Distance = distance - 1;
        Callback(firstStoppedElement);
    }
    private void UpdateBangSettings() {
        var main = bang.main;
        main.duration = duration;
        main.startSpeed = distance;
    }
    private void Callback(GameObject gameObject) {
        hitObjects.Add(gameObject);
        if(actionWithAttackedObjects == null)
            return;
        foreach(var action in actionWithAttackedObjects.GetInvocationList())
            ((Action<GameObject>)action)(gameObject);
    }
    

    private RaycastHit GetFirstStoppedElement(IEnumerable<RaycastHit> hitElements) {
        return hitElements.FirstOrDefault(ContainsInStoppedTags);
    }
    private Boolean ExistStoppedElement(IEnumerable<RaycastHit> hitElements) {
        return hitElements.ToList().Exists(ContainsInStoppedTags);
    }
    private Boolean ContainsInStoppedTags(RaycastHit hit) {
        return stoppedTags.Contains(hit.transform.gameObject.tag);
    }

    private Int32 GetNotZeroCoordinate(Vector3 distance) {
        if(distance.x != 0)
            return ToRoundInt32(distance.x);
        if(distance.y != 0)
            return ToRoundInt32(distance.y);
        return ToRoundInt32(distance.z);
    }
    private Int32 ToRoundInt32(Single value) {
        return Math.Abs((Int32)Math.Round(value));
    }
}
