using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LagGenerator : MonoBehaviour {
    [SerializeField] private GameObject m_prefab;

    private void FixedUpdate() {
        Instantiate(m_prefab);
    }
}
