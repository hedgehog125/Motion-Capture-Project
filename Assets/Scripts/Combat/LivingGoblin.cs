using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingGoblin : MonoBehaviour {
	[SerializeField] private int m_dieAfter;
	[SerializeField] private CombatUI m_combatUI;

	private int dieTick;
	private bool dead;

	private Animator anim;
	private void Awake() {
		anim = GetComponent<Animator>();
	}

	private void FixedUpdate() {
		if (dead) return;

		if (dieTick == m_dieAfter) {
			anim.SetBool("Die", true);
			m_combatUI.DecreaseMovesLeft();
			dead = true;
		}
		else {
			dieTick++;
		}
	}
}
