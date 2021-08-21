using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinigameTitle : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    public string minigameTitle = "TEST";

    private void Awake() {
        textMeshPro = GetComponent<TextMeshPro>();
    }

    void Start() {
        textMeshPro.text = minigameTitle;
    }
}
