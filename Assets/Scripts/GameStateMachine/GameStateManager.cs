/**
 * Game State Manager class uses for oparate game states.
 */

using UnityEngine;
using System.Collections;

public class GameStateManager : IGameStateManager {

	public IGameState mainMenuGameState;
	public IGameState gameState;
	public IGameState finishedGameState;

	private IGameState _currentGameState;
	public IGameState currentGameState {
		get {
			return _currentGameState;
		}
		set {
			_currentGameState = value;
		}
	}

	/// <summary>
	/// Init instance of GameStateManager class.
	/// </summary>
	public void Init() {
		mainMenuGameState = new MainMenuGameState();
		currentGameState = mainMenuGameState;
		currentGameState.EnableState();

		gameState = new GameState();
		finishedGameState = new LevelFinishedGameState();
	}

	/// <summary>
	/// Switchs the state of the game.
	/// </summary>
	/// <param name="newState">New state.</param>
	public void SwitchGameState(IGameState newState) {
		if(currentGameState != newState && currentGameState != null) {
			currentGameState.DisableState();
			currentGameState = newState;
			currentGameState.EnableState();
		}
	}
}
