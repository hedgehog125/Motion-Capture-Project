using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour {
	[SerializeField] private GameObject vis;
	[SerializeField] private int m_destroyTime;
	[SerializeField] private int m_deleteAfter;
	[SerializeField] private bool m_floating;

	private AudioSource destroySound;
	private Animator anim;

	private int destroyTick;

	private void Awake() {
		destroySound = vis.GetComponent<AudioSource>();
		anim = vis.GetComponent<Animator>();

		anim.SetBool("Floating", m_floating);
	}

	private void FixedUpdate() {
		if (destroyTick == m_destroyTime + m_deleteAfter) {
			Destroy(gameObject);
		}
		else if (destroyTick == m_destroyTime) {
			destroySound.Play();
			anim.SetBool("Destroyed", true);
		}

		destroyTick++;
	}
}
