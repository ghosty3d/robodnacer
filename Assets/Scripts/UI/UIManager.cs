using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject mainMenuPanel;
	public GameObject gamePanel;
	public GameObject pausePanel;
	public GameObject finishPanel;
	public GameObject optionsPanel;

	public RingWidget ringWidget;

	public ScoresWidget scoresWidget;
	public TimerWidget timerWidget;

	public void OnMainMenuModeEnabled() {
		mainMenuPanel.SetActive(true);
	}

	public void OnMainMenuModeDisabled() {
		mainMenuPanel.SetActive(false);
	}

	public void OnGameModeEnabled() {
		gamePanel.SetActive(true);
	}

	public void OnGameModeDisabled() {
		gamePanel.SetActive(false);
	}

	public void ShowPausePanel() {
		pausePanel.SetActive(true);
	}

	public void HidePausePanel() {
		pausePanel.SetActive(false);
	}

	public void ShowFinishPanel() {
		finishPanel.SetActive(true);
	}

	public void HideFinishPanel() {
		finishPanel.SetActive(false);
	}

	public void ShowOptionsPanel() {
		optionsPanel.SetActive(true);
	}

	public void HideOptionsPanel() {
		optionsPanel.SetActive(false);
	}
}
