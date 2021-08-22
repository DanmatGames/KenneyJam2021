using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocaController : MonoBehaviour
{
    private GameController gameController;
    private void Awake() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("EnemigoOrbita").Length == 0) {
            gameController.StopTimer(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "EnemigoOrbita") {
            gameController.StopTimer(true);
        }
    }
}
