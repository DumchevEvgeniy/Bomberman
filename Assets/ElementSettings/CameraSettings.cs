using UnityEngine;

public class CameraSettings : MonoBehaviour {
    public Camera cameraAboveThePlayer;
    private Quaternion cameraRotation = Quaternion.Euler(55, 270, 0);
    private Vector3 positionOffset = new Vector3(5, 8, 0);

    private void Start() {
        cameraAboveThePlayer = GetComponent<Camera>();
        Update();
    }

    private void Update() {
        var playerTransform = GetComponentInParent<Transform>().parent;
        cameraAboveThePlayer.transform.SetPositionAndRotation(playerTransform.position + positionOffset, cameraRotation);        
    }
}