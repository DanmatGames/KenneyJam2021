using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigamePiratasController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Ships").Length == 0)
        {
            Debug.Log("HOLIWI");
            SceneManager.LoadScene("ChumasScene");
        }
    }
}
