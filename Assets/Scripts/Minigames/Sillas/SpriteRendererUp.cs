using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteRendererUp : MonoBehaviour
{

    private GameController gameController;

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitColor());
        sr = GetComponent<SpriteRenderer>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator WaitColor()
    {

        yield return new WaitForSeconds(5);
        sr.color = Color.green;
    }
    private void OnMouseDown()
    {
        if (sr.color == Color.green)
        {
            gameController.StopTimer(false);
            SceneManager.LoadScene("Roulette");
        }
        else
        {
            gameController.StopTimer(true);
            SceneManager.LoadScene("Roulette");
        }
    }
}
