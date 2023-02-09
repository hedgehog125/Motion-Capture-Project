using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingGoblin : MonoBehaviour {
	[SerializeField] private int m_dieAfter;
	[SerializeField] private CombatUI m_combatUI;

	private int dieTick;
	private bool dead;

	private Animator anim;
	private AudioSource deathSound;
	private void Awake() {
		anim = GetComponent<Animator>();
		deathSound = GetComponent<AudioSource>();
	}

	private void FixedUpdate() {
		if (dead) return;

		if (dieTick == m_dieAfter) {
			anim.SetBool("Die", true);
			deathSound.Play();
			dead = true;

			m_combatUI.DecreaseMovesLeft();
		}
		else {
			dieTick++;
		}
	}
}
