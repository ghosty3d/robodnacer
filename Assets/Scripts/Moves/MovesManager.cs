using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovesManager : MonoBehaviour, IMoveObserver {

	public static MovesManager instance;
	public RectTransform comboPanel;

	public GameObject arrowPrefab;

	public int comboLength = 1;
	public int maxComboLength = 7;

	public int correctMoveScore = 5;
	public int arrowPadding = 128;

	public List<Combo> comboList = new List<Combo>();

	public Arrow currentArrow;

	void Awake() {
		instance = this;
	}

	public void StartToPlay() {
		InvokeRepeating("GenerateCombo", 1f, 3f);
	}

	public void StopToPlay() {
		ClearCombo();
		CancelInvoke("GenerateCombo");
		comboLength = 1;
		comboList.Clear();
		currentArrow = null;
	}

	public void GenerateCombo() {

		if(comboList.Count > 0 && comboList.Count % 3 == 0 && comboLength < maxComboLength) {
			comboLength++;				
		}

		Combo newCombo = new Combo(comboLength);

		for(int i = 0; i < newCombo.directionsList.Count; i++) {

			GameObject newArrowPrefab = null;

			switch(newCombo.directionsList[i]) {
				case DirectionsEnum.UP:
					newArrowPrefab = Instantiate(arrowPrefab, comboPanel) as GameObject;
					newArrowPrefab.GetComponent<Arrow>().arrowDirection = DirectionsEnum.UP;
					newArrowPrefab.name = "Arrow-Up-" + i;
					break;

				case DirectionsEnum.DOWN:
					newArrowPrefab = Instantiate(arrowPrefab, comboPanel) as GameObject;
					newArrowPrefab.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
					newArrowPrefab.GetComponent<Arrow>().arrowDirection = DirectionsEnum.DOWN;
					newArrowPrefab.name = "Arrow-Down-" + i;
					break;

				case DirectionsEnum.LEFT:
					newArrowPrefab = Instantiate(arrowPrefab, comboPanel) as GameObject;
					newArrowPrefab.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
					newArrowPrefab.GetComponent<Arrow>().arrowDirection = DirectionsEnum.LEFT;
					newArrowPrefab.name = "Arrow-Left-" + i;
					break;

				case DirectionsEnum.RIGHT:
					newArrowPrefab = Instantiate(arrowPrefab, comboPanel) as GameObject;
					newArrowPrefab.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
					newArrowPrefab.GetComponent<Arrow>().arrowDirection = DirectionsEnum.RIGHT;
					newArrowPrefab.name = "Arrow-Right-" + i;
					break;
			}

			Vector3 newPosition = new Vector3(((Screen.width * 0.5f) + (256 * i)), 0f, 0f);

			newArrowPrefab.transform.localScale = Vector3.one;
			newArrowPrefab.transform.localPosition = newPosition;
		}

		comboList.Add(newCombo);
	}

	public void ClearCombo() {
		if(comboPanel.childCount > 0) {
			for(int i = 0; i < comboPanel.childCount; i++) {
				Destroy(comboPanel.GetChild(i).gameObject);
			}
		}
	}

	public DirectionsEnum GetCurrentArrowDirection() {
		DirectionsEnum direction = DirectionsEnum.NONE;

		if(currentArrow != null) {
			direction = currentArrow.arrowDirection;
		}

		return direction;
	}

	public void UpdateMoveData(DirectionsEnum direction) {
		if(currentArrow != null) {
			if(direction == currentArrow.arrowDirection) {
				Core.instance.uiManager.scoresWidget.AddScores(correctMoveScore);
				currentArrow.AnimateCorrect();
				Core.instance.uiManager.ringWidget.AnimateCorrect();
			} else {
				currentArrow.AnimateWrong();
				Core.instance.uiManager.ringWidget.AnimateWrong();
			}
		}
	}
}
