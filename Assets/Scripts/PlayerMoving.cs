using System;
using UnityEngine;

public class PlayerMoving : MonoBehaviour {
    public Single speed = 2.5f;
    private CharacterController characterController;

    void Start () {
        characterController = GetComponent<CharacterController>();
	}
	
	void Update () {
        Single deltaX = -Input.GetAxis("Vertical") * speed;
        Single deltaZ = Input.GetAxis("Horizontal") * speed;
        var movement = new Vector3(deltaX, 0, deltaZ) * Time.deltaTime;
        characterController.Move(movement);
	}
}