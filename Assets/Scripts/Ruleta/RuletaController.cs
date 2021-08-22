using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuletaController : MonoBehaviour
{
    public GameController gameController;

    public Dictionary<int, string> ruletteMinigamesDictionary = new Dictionary<int, string>();

    public GameObject minigameTitlePrefab;
    public int minigamesAmount;
    public float ruletteRadius;

    private int minigameIndex;
    private float ruletteTime = 3f;
    private string selectedMinigame;

    private void Awake() {
        gameController = FindObjectOfType<GameController>();
    }
    void Start() {
        minigameIndex = minigamesAmount / 2;
        var totalMinigamesAmount = gameController.minigamesDictionary.Count;
        var minigameTextAngle = 180;
        var angleAmount = 360 / minigamesAmount;   

        for (var i=0; i<minigamesAmount; i++) {
            var newIndex = Random.Range(0, totalMinigamesAmount);

            while (ruletteMinigamesDictionary.ContainsKey(newIndex)) {
                newIndex = Random.Range(0, totalMinigamesAmount);
            }

            var newMinigame = gameController.minigamesDictionary[newIndex];
            ruletteMinigamesDictionary.Add(newIndex, newMinigame);

            var newMinigameTitle = Instantiate(minigameTitlePrefab, Vector3.zero, Quaternion.identity, this.transform);
            var newX = ruletteRadius * Mathf.Cos(Mathf.Deg2Rad*minigameTextAngle);
            var newY = ruletteRadius * Mathf.Sin(Mathf.Deg2Rad*minigameTextAngle);

            var newMinigameTitleClass = newMinigameTitle.GetComponentInChildren<MinigameTitle>();
            newMinigameTitleClass.minigameTitle = newMinigame;

            newMinigameTitle.transform.position = new Vector3(transform.position.x + newX, transform.position.y + newY);
            newMinigameTitle.transform.localEulerAngles = new Vector3(0f, 0f, minigameTextAngle - 180);

            minigameTextAngle += angleAmount;

            if (i == minigameIndex) {
                selectedMinigame = newMinigame;
            }
        }
    }

    void Update() {
        ruletteTime -= Time.deltaTime;

        if (ruletteTime <= 0f) {
            SceneManager.LoadScene(selectedMinigame);
            gameController.StartTimer();
        }
    }
}
