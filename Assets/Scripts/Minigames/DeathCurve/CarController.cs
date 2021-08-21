using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float carSpeed;

    private MinigameDeathCurveController minigameController;

    // Start is called before the first frame update
    void Start()
    {
        minigameController = GameObject.FindGameObjectWithTag("minigameController").GetComponent<MinigameDeathCurveController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento del coche
        this.transform.position += minigameController.direction * Time.deltaTime * carSpeed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //El jugador a perdido el minijuego
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //El jugador ha ganado el minijuego
        carSpeed = 0f;
    }
}
