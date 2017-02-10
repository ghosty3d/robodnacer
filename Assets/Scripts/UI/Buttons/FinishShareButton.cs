using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinishShareButton : Button {

	protected override void Awake() {
		base.Awake();
		this.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick () {
		Core.instance.facebookManager.ShareWithFacebook();
	}
}
