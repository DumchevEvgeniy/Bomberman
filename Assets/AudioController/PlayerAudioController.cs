using UnityEngine;

public class PlayerAudioController : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip stepAudio;
    public AudioClip deathAudio;
    public AudioClip deathAfterBangAudio;
    public AudioClip plantedBombAudio;
    public AudioClip takeABonusAudio;
    public AudioClip tauntAudio;

    public void Start() {
        audioSource = GetComponentInChildren<AudioSource>();
    }

    public void PlayStepAudio() {
        audioSource.PlayOneShot(stepAudio);
    }
    public void PlayDeathAudio() {
        audioSource.PlayOneShot(deathAudio);
    }
    public void PlayPlantedBombAudio() {
        audioSource.PlayOneShot(plantedBombAudio);
    }
    public void PlayTakeAbonusAudio() {
        audioSource.PlayOneShot(takeABonusAudio);
    }
    public void PlayDeathAfterBangAudio() {
        audioSource.PlayOneShot(deathAfterBangAudio);
    }
    public void PlayTauntAudio() {
        audioSource.PlayOneShot(tauntAudio);
    }
}
