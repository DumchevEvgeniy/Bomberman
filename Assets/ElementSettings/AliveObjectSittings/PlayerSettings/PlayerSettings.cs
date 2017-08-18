using System;
using UnityEngine;

public class PlayerSettings : WallpassPlayerSettings {
    public Int32 numberOfLives = 3;
    public Int32 gamePoints = 0;
    
    public void Initialize(Int32 numberOfLives, Int32 gamePoints) {
        this.numberOfLives = numberOfLives;
        this.gamePoints = gamePoints;        
    }

    public override void Die() {
        DeactivateCharacterController();
        DeactivateAudioListener();
        base.Die();
        numberOfLives--;
    }

    private void DeactivateAudioListener() {
        SetEnableForAudioListener(gameObject, false);
        var mainCamera = gameObject.scene.FindMainCamera();
        if(mainCamera != null)
            SetEnableForAudioListener(mainCamera, true);
    }
    private void SetEnableForAudioListener(GameObject gameObject, Boolean enable) {
        var audioListener = gameObject.GetComponent<AudioListener>();
        if(audioListener != null)
            audioListener.enabled = enable;
    }

    private void DeactivateCharacterController() {
        var character = GetComponent<CharacterController>();
        if(character != null)
            character.enabled = false;
    }
}
