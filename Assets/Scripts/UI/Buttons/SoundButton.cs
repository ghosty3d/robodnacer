using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundButton : Button {

	public bool isSoundEnabled = true;
	private Animator animator;

	protected override void Awake() {
		base.Awake();
		animator = GetComponent<Animator>();
		this.onClick.AddListener(OnCloseButtonClick);
	}

	void OnCloseButtonClick() {
		Core.instance.audioManager.ToggleSound();

		if(isSoundEnabled) {
			animator.SetTrigger("Off");
			isSoundEnabled = false;
		} else {
			animator.SetTrigger("On");
			isSoundEnabled = true;
		}
	}
}
