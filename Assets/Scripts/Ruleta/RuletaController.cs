using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuletaController : MonoBehaviour
{
    public GameController gameController;

    public Dictionary<int, string> ruletteMinigamesDictionary = new Dictionary<int, string>();

    public int minigamesAmount = 2;
    public int initialIndex = 0;
    public int minigameIndex = 0;

    private void Awake() {
        gameController = FindObjectOfType<GameController>();
    }
    void Start() {
        var totalMinigamesAmount = gameController.minigamesDictionary.Count;
        for (var i=0; i<minigamesAmount; i++) {
            var newIndex = Random.Range(0, totalMinigamesAmount);

            while (ruletteMinigamesDictionary.ContainsKey(newIndex)) {
                newIndex = Random.Range(0, totalMinigamesAmount);
            }

            var newMinigame = gameController.minigamesDictionary[newIndex];
            ruletteMinigamesDictionary.Add(newIndex, newMinigame);
        }
    }

    void Update() {
        
    }
}
