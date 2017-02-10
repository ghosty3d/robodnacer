using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoresWidget : MonoBehaviour {

	public int scores = 0;
	public Text scoresText;

	public void AddScores(int newScores) {
		scores += newScores;
		scoresText.text = string.Format("Scores: {0}", scores);
		Core.instance.currentPlayerProfile.SaveScores(scores);
	}

}
