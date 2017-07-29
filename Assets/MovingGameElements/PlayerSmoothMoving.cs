using System;
using System.Collections;
using UnityEngine;

public class PlayerSmoothMoving : MonoBehaviour {
    public Single distance = 2.5f;
    public Single step = 0.05f;
    public Single endTime = 0.1f;
    private CharacterController characterController;
    private Boolean startedCoroutine;

    void Start() {
        characterController = GetComponent<CharacterController>();
        startedCoroutine = false;
    }

    void Update() {
        Single deltaX = -Input.GetAxis("Vertical") * distance;
        Single deltaZ = Input.GetAxis("Horizontal") * distance;
        if(deltaX == 0 && deltaZ == 0)
            return;
        if(!startedCoroutine)
            StartCoroutine(SmoothMoving(deltaX, deltaZ));
    }

    private IEnumerator SmoothMoving(Single deltaX, Single deltaZ) {
        startedCoroutine = true;
        var startTime = step;
        var endPosition = new Vector3(transform.position.x + deltaX, transform.position.y, transform.position.z + deltaZ); 
        while(startTime < endTime) {
            var startPosition = transform.position;
            var movement = Vector3.Lerp(startPosition, endPosition, step);
            characterController.Move(movement - startPosition);
            yield return new WaitForEndOfFrame();
            startTime += step;
        }
        startedCoroutine = false;
    }
}