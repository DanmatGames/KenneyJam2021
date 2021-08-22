using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigamePiratasController : MonoBehaviour
{

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioSource audio = GetComponent<AudioSource>();

            audio.Play();  // plays sound when collided.
        }
        if (GameObject.FindGameObjectsWithTag("Ships").Length == 0)
        {
            gameController.StopTimer(false);
        }
    }
}
