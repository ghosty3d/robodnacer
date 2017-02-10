using UnityEngine;
using System.Collections;

public class MainMenuGameState : IGameState {

	public void EnableState() {
		//Debug.Log("Main Menu Game State Enabled!");
		Core.instance.uiManager.OnMainMenuModeEnabled();
	}

	public void DisableState() {
		//Debug.Log("Main Menu Game State Disabled!");
		Core.instance.uiManager.OnMainMenuModeDisabled();
	}

}
