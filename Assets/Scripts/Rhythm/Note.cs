using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Note : ScriptableObject {
	public enum Color {
		Red,
		Unused,
		Blue,
		Unused2
	}
	public Color color;

	public int beatTime;
}
