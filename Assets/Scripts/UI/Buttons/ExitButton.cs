using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitButton : Button {

	protected override void Awake() {
		base.Awake();
		this.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick () {
		Application.Quit();
	}
}
