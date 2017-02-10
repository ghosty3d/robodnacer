using UnityEngine;
using System.Collections;

public class LevelFinishedGameState : IGameState {

	public void EnableState() {
		Core.instance.uiManager.ShowFinishPanel();
	}

	public void DisableState() {
		Core.instance.uiManager.HideFinishPanel();
	}
}
