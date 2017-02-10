using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Combo {

	public List<DirectionsEnum> directionsList = new List<DirectionsEnum>();

	public Combo(int comboLength) {

		System.Random prng = new System.Random();

		for(int i = 0; i < comboLength; i++) {
			int directionIndex = prng.Next(0, Enum.GetNames(typeof(DirectionsEnum)).Length - 1);
			directionsList.Add((DirectionsEnum)directionIndex);
		}
	}
}
