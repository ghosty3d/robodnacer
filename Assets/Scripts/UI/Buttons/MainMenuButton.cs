using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuButton : Button {

	protected override void Awake() {
		base.Awake();
		this.onClick.AddListener(OnButtonClick);
	}
	
	void OnButtonClick() {
		Time.timeScale = 1;
		Core.instance.uiManager.HidePausePanel();
		Core.instance.gameStateManager.SwitchGameState(Core.instance.gameStateManager.mainMenuGameState);
	}
}
