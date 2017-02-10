using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour, IMoveNotifier {
	
	public static InputManager instance;

	public DirectionsEnum moveDirection = DirectionsEnum.NONE;

	private IMoveObserver moveObserver;
	private IMoveObserver playerController;

	//Touch
	private float fingerStartTime  = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;

	private bool isSwipe = false;
	private float minSwipeDist  = 50.0f;
	private float maxSwipeTime = 0.5f;

	public void Init() {
		moveObserver = Core.instance.movesManager;
		playerController = Core.instance.playerController;
	}

	void Awake() {
		instance = this;
	}

	void Update () {
		#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			Debug.Log("Up Arrow");
			moveDirection = DirectionsEnum.UP;
			NotifyMoveObserver();
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			Debug.Log("Down Arrow");
			moveDirection = DirectionsEnum.DOWN;
			NotifyMoveObserver();
		} else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			Debug.Log("Left Arrow");
			moveDirection = DirectionsEnum.LEFT;
			NotifyMoveObserver();
		} else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			Debug.Log("Right Arrow");
			moveDirection = DirectionsEnum.RIGHT;
			NotifyMoveObserver();
		}

		if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) {
			moveDirection = DirectionsEnum.NONE;
		}
		#endif

		#if UNITY_ANDROID || UNITY_IOS
		if (Input.touchCount > 0) {
			foreach (Touch touch in Input.touches) {
				switch (touch.phase) {
					case TouchPhase.Began :
						/* this is a new touch */
						isSwipe = true;
						fingerStartTime = Time.time;
						fingerStartPos = touch.position;
						break;

					case TouchPhase.Canceled :
						/* The touch is being canceled */
						isSwipe = false;
						break;

					case TouchPhase.Ended :

						float gestureTime = Time.time - fingerStartTime;
						float gestureDist = (touch.position - fingerStartPos).magnitude;

						if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist) {
							Vector2 direction = touch.position - fingerStartPos;
							Vector2 swipeType = Vector2.zero;

							if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
								// the swipe is horizontal:
								swipeType = Vector2.right * Mathf.Sign(direction.x);
							} else {
								// the swipe is vertical:
								swipeType = Vector2.up * Mathf.Sign(direction.y);
							}

							if(swipeType.x != 0.0f) {
								if(swipeType.x > 0.0f) {
									// MOVE RIGHT
									moveDirection = DirectionsEnum.RIGHT;
									NotifyMoveObserver();
								} else {
									// MOVE LEFT
									moveDirection = DirectionsEnum.LEFT;
									NotifyMoveObserver();
								}
							}

							if(swipeType.y != 0.0f) {
								if(swipeType.y > 0.0f) {
									// MOVE UP
									moveDirection = DirectionsEnum.UP;
									NotifyMoveObserver();
								} else {
									// MOVE DOWN
									moveDirection = DirectionsEnum.DOWN;
									NotifyMoveObserver();
								}
							}
						}

						break;
					}
				}
			}
		#endif
	}

	public void NotifyMoveObserver() {
		moveObserver.UpdateMoveData(moveDirection);
		playerController.UpdateMoveData(moveDirection);
	}
}
