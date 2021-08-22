using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouLostController : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(GameObject.FindGameObjectWithTag("GameController"));
        SceneManager.LoadScene("MainMenu");
    }
}
