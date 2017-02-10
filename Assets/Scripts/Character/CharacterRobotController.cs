/**
 * Character Robot Controller class uses for oparate Robot Animations.
 */

using UnityEngine;
using System.Collections;

public class CharacterRobotController : MonoBehaviour, IMoveObserver {

	private Animator animator;

	void Awake () {
		animator = GetComponent<Animator>();
	}


	/// <summary>
	/// Set Animator Trigger parametr according move direction.
	/// </summary>
	/// <param name="direction">Move Direction.</param>
	public void UpdateMoveData(DirectionsEnum direction) {
		switch(direction) {
			case DirectionsEnum.UP:
				animator.SetTrigger("Up");
				break;

			case DirectionsEnum.DOWN:
				animator.SetTrigger("Down");
				break;

			case DirectionsEnum.LEFT:
				animator.SetTrigger("Left");
				break;

			case DirectionsEnum.RIGHT:
				animator.SetTrigger("Right");
				break;
		}
	}
}
