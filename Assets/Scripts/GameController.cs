using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Dictionary<int, string> minigamesDictionary = new Dictionary<int, string>();

    private void Awake() {
        minigamesDictionary.Add(0, "Minigame A");
        minigamesDictionary.Add(1, "Minigame B");
        minigamesDictionary.Add(2, "Minigame C");
        minigamesDictionary.Add(3, "Minigame D");
        minigamesDictionary.Add(4, "Minigame E");
        minigamesDictionary.Add(5, "Minigame F");
        minigamesDictionary.Add(6, "Minigame G");
        minigamesDictionary.Add(7, "Minigame H");
        minigamesDictionary.Add(8, "Minigame I");
        minigamesDictionary.Add(9, "Minigame J");
        minigamesDictionary.Add(10, "Minigame K");
        minigamesDictionary.Add(11, "Minigame L");
        minigamesDictionary.Add(12, "Minigame M");
        minigamesDictionary.Add(13, "Minigame N");
        minigamesDictionary.Add(14, "Minigame O");
        minigamesDictionary.Add(15, "Minigame P");
        minigamesDictionary.Add(16, "Minigame Q");
        minigamesDictionary.Add(17, "Minigame R");
        minigamesDictionary.Add(18, "Minigame S");
        minigamesDictionary.Add(19, "Minigame T");
        minigamesDictionary.Add(20, "Minigame U");
        minigamesDictionary.Add(21, "Minigame V");
        minigamesDictionary.Add(22, "Minigame W");
        minigamesDictionary.Add(23, "Minigame X");
        minigamesDictionary.Add(24, "Minigame Y");
        minigamesDictionary.Add(25, "Minigame Z");
        minigamesDictionary.Add(26, "Danmat");
        minigamesDictionary.Add(27, "Darsirious");
        minigamesDictionary.Add(28, "Chumas");
        minigamesDictionary.Add(29, "Lacho");
    }

    void Update() {
        
    }
}
