using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameArrow : MonoBehaviour
{
    public float oscillationDistance;
    public float oscillationSpeed;

    private float initialXPosition;
    private float currentAngle;
    private float xOffset;
    // Start is called before the first frame update
    void Start() {
        initialXPosition = transform.position.x;
        currentAngle = 0;
    }

    // Update is called once per frame
    void Update() {
        currentAngle += oscillationSpeed;
        if (currentAngle > 360) {
            currentAngle -= 360;
        }

        xOffset = oscillationDistance * Mathf.Cos(Mathf.Deg2Rad * currentAngle);
        transform.position = new Vector3(initialXPosition + xOffset, transform.position.y);
    }
}
