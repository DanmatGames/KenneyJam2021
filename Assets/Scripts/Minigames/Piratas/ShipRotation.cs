using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotation : MonoBehaviour
{

    public GameObject anchor;
    public float velocidad;

    // Start is called before the first frame update
    void Start()
    {
        velocidad = 70f;
    }

    // Update is called once per frame
    void Update()
    {
        //mueve el barco alrededor de el anchor y no deja que rote �l mismo
        transform.RotateAround(anchor.transform.localPosition, Vector3.back, Time.deltaTime * velocidad);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
    //mata los barcos clickandoles encima
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(this.gameObject);
        }
    }
}
