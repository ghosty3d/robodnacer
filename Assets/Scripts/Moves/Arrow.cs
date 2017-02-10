using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Arrow : MonoBehaviour, IConditionAnimable {

	public float slideSpeed = 3f;
	public DirectionsEnum arrowDirection;

	public float detectionRange = 65f;

	private RectTransform rectTransform;

	private Animator animator;

	void Awake() {
		rectTransform = GetComponent<RectTransform>();
		animator = GetComponent<Animator>();
	}

	void Update () {
		//Translate Arrow just after instantiation
		transform.Translate(Vector3.left * slideSpeed * Time.deltaTime, Space.World);

		//Check if Arrow inside defined range make it Active
		if(rectTransform.localPosition.x > -detectionRange && rectTransform.localPosition.x < detectionRange) {
			MakeActive();
		} else {
			MakeInactive();
		}

		//Remove Arrow after outgoing left screen border
		if(rectTransform.localPosition.x < -668) {
			MakeInactive();
			Destroy(this.gameObject);
		}
	}

	public void MakeActive() {
		MovesManager.instance.currentArrow = this;
	}

	public void MakeInactive() {
		if(MovesManager.instance.currentArrow == this) {
			MovesManager.instance.currentArrow = null;	
		}
	}

	public void AnimateCorrect() {
		animator.SetTrigger("Correct");
	}

	public void AnimateWrong() {
		animator.SetTrigger("Wrong");
	}
}