using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoOrbita : MonoBehaviour
{
    public Transform targetPoint;
    private float enemySpeed;

    // Start is called before the first frame update
    void Start() {
        enemySpeed = Random.Range(1f, 2f);
    }

    // Update is called once per frame
    void Update() {
        var newPosition = Vector3.MoveTowards(transform.position, targetPoint.position, enemySpeed*Time.deltaTime);

        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            Destroy(gameObject);
        }
    }
}
