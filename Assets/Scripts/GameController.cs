using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Dictionary<int, string> minigamesDictionary = new Dictionary<int, string>();
    void Start() {
        minigamesDictionary.Add(0, "Minigame A");
        minigamesDictionary.Add(1, "Minigame B");
        minigamesDictionary.Add(2, "Minigame C");
        minigamesDictionary.Add(3, "Minigame D");
        minigamesDictionary.Add(4, "Minigame E");
    }

    void Update() {
        
    }
}
