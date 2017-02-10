using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResumeButton : Button {

	protected override void Awake() {
		base.Awake();
		this.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick() {
		Core.instance.uiManager.HidePausePanel();
		Time.timeScale = 1;
	}
}
