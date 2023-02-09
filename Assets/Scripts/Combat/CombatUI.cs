using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatUI : MonoBehaviour {
	[SerializeField] private TextMeshProUGUI movesLeftText;

	private int movesLeft = 2;
	public void DecreaseMovesLeft() {
		movesLeft--;
		movesLeftText.text = $"Moves Left: {movesLeft}";
	}
}
