using UnityEngine;
using System.Collections;

public class TimerManager : MonoBehaviour, ITimerNotifier {

	public static TimerManager instance;

	public int currentTimerValue = 0;
	public int maxTimerValue = 30;

	private ITimerObserver timerObserver;

	void Awake () {
		instance = this;
		timerObserver = Core.instance.uiManager.timerWidget;
	}

	public void StartTimer() {
		currentTimerValue = maxTimerValue;
		NotifyTimerUpdate();
		StartCoroutine("UpdateTimer");
	}

	public void StopTimer() {
		StopAllCoroutines();
		currentTimerValue = 0;
		NotifyTimerFinished();
	}

	IEnumerator UpdateTimer() {
		while(currentTimerValue > 0) {
			yield return new WaitForSeconds(1f);
			currentTimerValue--;
			NotifyTimerUpdate();
		}

		NotifyTimerFinished();

		Core.instance.gameStateManager.SwitchGameState(Core.instance.gameStateManager.finishedGameState);
	}

	public void NotifyTimerUpdate() {
		timerObserver.UpdateTimerData(currentTimerValue);
	}

	public void NotifyTimerFinished() {
		
	}
}
