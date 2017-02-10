/**
 * Base class used for linking all managers.
 */

using UnityEngine;
using System.Collections;

public class Core : MonoBehaviour {

	public static Core instance;

	public GameStateManager gameStateManager;
	public FacebookManager facebookManager;
	public MovesManager movesManager;
	public UIManager uiManager;
	public InputManager inputManager;
	public CharacterRobotController playerController;
	public AudioManager audioManager;
	public TimerManager timerManager;

	public PlayerProfile currentPlayerProfile;

	void Awake () {
		instance = this;
		Init();
	}

	void Init() {

		if(currentPlayerProfile == null) {
			currentPlayerProfile = new PlayerProfile();
		}

		if(gameStateManager == null) {
			gameStateManager = new GameStateManager();
		}

		if(facebookManager == null) {
			facebookManager = new FacebookManager();
		}

		if(movesManager == null) {
			movesManager = MovesManager.instance;
		}

		if(inputManager == null) {
			inputManager = InputManager.instance;	
		}

		if(audioManager == null) {
			audioManager = AudioManager.instance;
		}

		gameStateManager.Init();
		facebookManager.Init();
		inputManager.Init();
	}
}
