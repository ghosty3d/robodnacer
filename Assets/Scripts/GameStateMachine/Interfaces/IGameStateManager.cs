using UnityEngine;
using System.Collections;

public interface IGameStateManager {

	void Init();
	void SwitchGameState (IGameState newState);
}
