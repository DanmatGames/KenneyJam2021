using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    private float timeLeft;
    private Image timerBar;
    private Image live1, live2, live3;
    private bool startTimer = false;
    private bool lost = false;

    public Dictionary<int, string> minigamesDictionary = new Dictionary<int, string>();

    public int lives;
    public float gameSpeed;
    public float minigamesTimer;

    public GameObject filledBar;
    public GameObject livesPanel;

    private void Awake() 
    {
        if(Instance == null)
        {
            Instance= this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        minigamesDictionary.Add(0, "AlienOrbit");
        minigamesDictionary.Add(1, "PirateShips");
        minigamesDictionary.Add(2, "MusicalChairs");
        minigamesDictionary.Add(3, "RocketPlane");
        minigamesDictionary.Add(4, "DeathCurve");
        minigamesDictionary.Add(5, "AlienOrbit");
        minigamesDictionary.Add(6, "PirateShips");
        minigamesDictionary.Add(7, "MusicalChairs");
        minigamesDictionary.Add(8, "RocketPlane");
        minigamesDictionary.Add(9, "DeathCurve");

        timerBar = filledBar.GetComponent<Image>();
        live1 = livesPanel.transform.GetChild(0).GetComponent<Image>();
        live2 = livesPanel.transform.GetChild(1).GetComponent<Image>();
        live3 = livesPanel.transform.GetChild(2).GetComponent<Image>();
    }

    void Update() {
        if(startTimer)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timerBar.fillAmount = timeLeft / minigamesTimer;
            }
            else
            {
                StopTimer(true);
            }
        }
    }

    public void StartTimer()
    {
        timeLeft = minigamesTimer;
        startTimer = true;
    }

    public void StopTimer(bool lostMinigame)
    {
        startTimer = false;
        if(lostMinigame) removeLive();
        if (!lost)
        {
            timerBar.fillAmount = minigamesTimer;
            SceneManager.LoadScene("Roulette");
        }
    }

    private void removeLive()
    {
        lives--;
        switch (lives)
        {
            case 2:
                live3.color = Color.white;
                break;
            case 1:
                live2.color = Color.white;
                break;
            case 0:
                live1.color = Color.white;
                lost = true;
                SceneManager.LoadScene("YouLost");
                break;
        }
    }
}
