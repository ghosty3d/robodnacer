using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsButton : Button {

	protected override void Awake() {
		base.Awake();
		this.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick () {
		Core.instance.uiManager.ShowOptionsPanel();
	}
}
