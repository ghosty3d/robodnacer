using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundVolumeSlider : Slider {

	protected override void Awake() {
		base.Awake();
		this.onValueChanged.AddListener(OnValueChanged);
	}

	void OnValueChanged (float value) {
		Core.instance.audioManager.AdjustVolume(value);
	}
}
