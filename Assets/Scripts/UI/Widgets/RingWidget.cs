using UnityEngine;
using System.Collections;

public class RingWidget : MonoBehaviour, IConditionAnimable {

	private Animator animator;

	void Awake() {
		animator = GetComponent<Animator>();
	}

	public void AnimateCorrect() {
		animator.SetTrigger("Correct");
	}

	public void AnimateWrong() {
		animator.SetTrigger("Wrong");
	}
}
