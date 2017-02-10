using UnityEngine;
using System.Collections;

public interface ITimerNotifier {

	void StartTimer();
	void StopTimer();
	void NotifyTimerUpdate();
	void NotifyTimerFinished();
}
