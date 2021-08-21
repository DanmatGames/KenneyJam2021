using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersRotation : MonoBehaviour
{

    public GameObject anchor;
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(anchor.transform.localPosition, Vector3.back, Time.deltaTime * velocidad);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
