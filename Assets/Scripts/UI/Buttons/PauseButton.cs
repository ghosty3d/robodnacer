using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseButton : Button {

	protected override void Awake() {
		base.Awake();
		this.onClick.AddListener(OnButtonClick);
	}
	
	void OnButtonClick() {
		Core.instance.uiManager.ShowPausePanel();
		Time.timeScale = 0;
	}
}
