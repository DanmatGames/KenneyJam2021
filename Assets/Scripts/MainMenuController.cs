using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenuController : MonoBehaviour
{
    public GameObject playTextGameObject;
    private Text playText;
    
    public Color hoverColor;

    // Start is called before the first frame update
    void Start()
    {
        playText = playTextGameObject.GetComponent<Text>();
    }

    public void OnMouseEnterButton()
    {
        playText.color = hoverColor;
    }

    public void OnMouseExitButton()
    {
        playText.color = Color.white;
    }

    public void OnClick()
    {
        SceneManager.LoadScene("Roulette");
    }
}
