using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloseButton : Button {

	protected override void Awake() {
		base.Awake();
		this.onClick.AddListener(OnCloseButtonClick);
	}

	void OnCloseButtonClick() {
		Core.instance.uiManager.HideOptionsPanel();
	}
}
