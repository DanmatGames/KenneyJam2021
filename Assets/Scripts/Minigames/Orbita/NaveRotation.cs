using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveRotation : MonoBehaviour
{
  
    public GameObject anchor;
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = 80f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(anchor.transform.localPosition, Vector3.back, Time.deltaTime * velocidad);
        //transform.localRotation = Quaternion.Euler(0, 0, 0);
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
