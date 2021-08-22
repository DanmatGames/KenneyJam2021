using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteRendererUp : MonoBehaviour
{

    private GameController gameController;

    public GameObject rotatePoint;

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        float marginTime = gameController.minigamesTimer / 4;
        float randomTime = Random.Range(marginTime, gameController.minigamesTimer - marginTime);
        StartCoroutine(WaitColor(randomTime, Color.green));
        StartCoroutine(WaitColor(randomTime+1, Color.red));
    }

    IEnumerator WaitColor(float time, Color color)
    {
        yield return new WaitForSeconds(time);
        sr.color = color;
    }

    private void Update()
    {
        if (sr.color == Color.green)
        {
            for(int i = 0; i < 4; i++)
            {
                PlayersRotation playersRotation = rotatePoint.transform.GetChild(i).GetComponent<PlayersRotation>();
                playersRotation.velocidad = 0f;
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                PlayersRotation playersRotation = rotatePoint.transform.GetChild(i).GetComponent<PlayersRotation>();
                playersRotation.velocidad = 100f;
            }
        }
    }

    private void OnMouseDown()
    {
        if (sr.color == Color.green)
        {
            gameController.StopTimer(false);
        }
        else
        {
            gameController.StopTimer(true);
        }
    }
}
