using UnityEngine;
using System.Collections;

public class GameState : IGameState {

	public void EnableState() {
		Core.instance.uiManager.OnGameModeEnabled();
		Core.instance.timerManager.StartTimer();
		Core.instance.movesManager.StartToPlay();
	}

	public void DisableState() {
		Core.instance.uiManager.OnGameModeDisabled();
		Core.instance.timerManager.StopTimer();
		Core.instance.movesManager.StopToPlay();
	}
}
