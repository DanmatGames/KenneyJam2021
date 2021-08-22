using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvionController : MonoBehaviour
{
    public bool shipRotating = false;
    public Transform leftTransform;
    public Transform middleTransform;
    public Transform rightTransform;

    public GameObject leftArrow;
    public GameObject rightArrow;

    public Transform initialTransform;
    public Transform targetTransform;

    private float timeToPoint = 1f;

    // Start is called before the first frame update
    void Start() {
        initialTransform = middleTransform;
        targetTransform = middleTransform;
    }

    // Update is called once per frame
    void Update() {
        if (shipRotating) {
            timeToPoint -= Time.deltaTime;
            var xPosition = Mathf.Lerp(initialTransform.position.x, targetTransform.position.x, 1f - timeToPoint);
            transform.position = new Vector3(xPosition, transform.position.y);

            if (timeToPoint <= 0f) {
                shipRotating = false;
                timeToPoint = 1f;

                initialTransform = targetTransform;

                if (initialTransform != leftTransform) {
                    leftArrow.SetActive(true);
                }

                if (initialTransform != rightTransform) {
                    rightArrow.SetActive(true);
                }
            }
        }
    }
}
