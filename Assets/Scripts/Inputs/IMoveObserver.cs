using UnityEngine;
using System.Collections;

public interface IMoveObserver {
	void UpdateMoveData(DirectionsEnum direction);
}
