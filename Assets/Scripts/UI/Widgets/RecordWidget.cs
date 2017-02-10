using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RecordWidget : MonoBehaviour {

	public int record = 0;
	public Text scoresText;

	void Start() {
		UpdateRecord();
	}

	public void UpdateRecord() {
		record = Core.instance.currentPlayerProfile.GetScores();
		scoresText.text = string.Format("Record: {0}", record);
	}
}

