/**
 * Audio Manager class used for oparate Audio Source, sounds and SFX.
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	private AudioSource audioSource;
	private bool isAudioActive = true;

	void Awake () {
		instance = this;
		audioSource = GetComponent<AudioSource>();
	}

	/// <summary>
	/// Toggles the sound. On or Off.
	/// </summary>
	public void ToggleSound() {
		if(isAudioActive) {
			audioSource.volume = 0;
			isAudioActive= false;
		} else {
			audioSource.volume = 1;
			isAudioActive= true;
		}
	}

	/// <summary>
	/// Adjusts Audio Source volume.
	/// </summary>
	/// <param name="volume">Volume.</param>
	public void AdjustVolume(float volume) {
		audioSource.volume = Mathf.Clamp(volume, 0f, 1f);
	}
}
