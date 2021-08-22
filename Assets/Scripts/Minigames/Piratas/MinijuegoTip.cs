using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinijuegoTip : MonoBehaviour
{

    public GameObject UiObject;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(WaitUi());
    }
    IEnumerator WaitUi()
    {

        yield return new WaitForSeconds(1.5f);
        UiObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
