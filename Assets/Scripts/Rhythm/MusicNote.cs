using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNote : MonoBehaviour {
	[SerializeField] private float m_speed;
	[SerializeField] private float m_laneWidth;
	[SerializeField] private int m_laneCount;
	[SerializeField] private float m_playZPos;

	[HideInInspector] public Note noteData;

	private bool soundPlayed;

	private Renderer ren;
	private AudioSource snd;
	private void Awake() {
		ren = GetComponent<Renderer>();
		snd = GetComponent<AudioSource>();
	}

	private void Start() {
		float arriveDelaySeconds = noteData.beatTime / 50f;

		float leftMost = m_laneWidth * ((m_laneCount / 2f) - 0.5f);
		transform.localPosition = new Vector3(
            leftMost - ((int)noteData.color * m_laneWidth), // The colours determine the position. The first enum is the leftmost
			0,
			-(arriveDelaySeconds * m_speed)
		);

		ren.material = noteData.material;
		snd.clip = noteData.sound;
	}

	private void FixedUpdate() {
		if (ren.enabled) {
			if (transform.localPosition.z > 0f) {
				ren.enabled = false;
			}
		}

        if (soundPlayed) {
            if (! snd.isPlaying) {
                Destroy(gameObject);
                return;
            }
        }
        else {
            if (transform.localPosition.z > m_playZPos) {
                snd.Play();
                soundPlayed = true;
            }
        }
    }
	private void Update() {
		Vector3 pos = transform.position;

		pos.z += m_speed * Time.deltaTime;

		transform.position = pos;
	}
}
