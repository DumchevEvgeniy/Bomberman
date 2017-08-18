using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyAudioController : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip stepAudio;
    public AudioClip deathAfterBangAudio;
    public AudioClip tauntAudio;
    public AudioClip damageAudio;

    public void Start() {
        audioSource = GetComponentInChildren<AudioSource>();
    }

    public void PlayStepAudio() {
        audioSource.PlayOneShot(stepAudio);
    }
    public void PlayDeathAfterBangAudio() {
        audioSource.PlayOneShot(deathAfterBangAudio);
    }
    public void PlayTauntAudio() {
        audioSource.PlayOneShot(tauntAudio);
    }
    public void PlayDamageAudio() {
        audioSource.PlayOneShot(damageAudio);
    }
}
