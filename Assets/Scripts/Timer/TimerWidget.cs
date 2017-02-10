using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerWidget : MonoBehaviour, ITimerObserver {

	public Text timerLabel;

	public void UpdateTimerData(int timerValue) {
		timerLabel.text = string.Format("0:{0}", timerValue);
	}
}
