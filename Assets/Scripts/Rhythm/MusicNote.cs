using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNote : MonoBehaviour {
	[SerializeField] private float m_speed;
	[SerializeField] private float m_laneWidth;
	[SerializeField] private int m_laneCount;

	[HideInInspector] public Note NoteData;

	private void Start() {
		float arriveDelaySeconds = NoteData.beatTime / 50f;

		float leftMost = m_laneWidth * ((m_laneCount / 2f) - 0.5f);
		transform.localPosition = new Vector3(
            leftMost - ((int)NoteData.color * m_laneWidth), // The colours determine the position. The first enum is the leftmost
			0,
			-(arriveDelaySeconds * m_speed)
		);
	}

	private void FixedUpdate() {
		if (transform.localPosition.z > 0f) {
			Destroy(gameObject);
			return;
		}
	}
	private void Update() {
		Vector3 pos = transform.position;

		pos.z += m_speed * Time.deltaTime;

		transform.position = pos;
	}
}
