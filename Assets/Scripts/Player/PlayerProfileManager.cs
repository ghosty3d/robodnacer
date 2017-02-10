using UnityEngine;
using System.Collections;

public class PlayerProfileManager : MonoBehaviour {

	public static PlayerProfileManager instance;

	void Awake () {
		instance = this;
	}
}
