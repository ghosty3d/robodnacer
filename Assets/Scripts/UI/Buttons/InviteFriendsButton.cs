using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InviteFriendsButton : Button {

	protected override void Awake() {
		base.Awake();
		this.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick () {
		Core.instance.facebookManager.InviteFriends();
	}
}
