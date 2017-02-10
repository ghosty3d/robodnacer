using UnityEngine;
using System.Collections;

public class PlayerProfile {

	public PlayerProfile() {
		
	}

	public void SaveScores(int scores) {
		PlayerPrefs.SetInt("scores", scores);
	}

	public int GetScores() {
		return PlayerPrefs.GetInt("scores");
	}

	public void ResetScores() {
		PlayerPrefs.SetInt("scores", 0);
	}
}
