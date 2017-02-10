using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayButton : Button {

	protected override void Awake() {
		base.Awake();
		this.onClick.AddListener(OnPlayButtonClick);
	}

	void OnPlayButtonClick() {
		Core.instance.gameStateManager.SwitchGameState(Core.instance.gameStateManager.gameState);
		if(Core.instance.uiManager.finishPanel.activeInHierarchy) {
			Core.instance.uiManager.HideFinishPanel();
		}
	}
}
