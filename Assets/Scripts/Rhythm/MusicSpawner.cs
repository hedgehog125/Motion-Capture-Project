using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSpawner : MonoBehaviour {
	[SerializeField] private List<Note> m_notes;
	[SerializeField] private GameObject m_notePrefab;

	private void Start() {
		foreach (Note noteData in m_notes) {
			GameObject note = Instantiate(m_notePrefab);
			note.transform.parent = transform;

			note.GetComponent<MusicNote>().NoteData = noteData;
		}
	}
}
