using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuletaController : MonoBehaviour
{
    public GameController gameController;
    public int initialIndex = 0;
    public int minigameIndex = 0;

    private void Awake() {
        gameController = FindObjectOfType<GameController>();
    }
    void Start() {
        var minigamesAmount = gameController.minigamesList.Count;
        initialIndex = Random.Range(0, minigamesAmount);
    }

    void Update() {
        
    }
}
