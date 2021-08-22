using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvionController : MonoBehaviour
{
    private GameController gameController;
    public bool shipRotating = false;
    public Transform leftTransform;
    public Transform middleTransform;
    public Transform rightTransform;

    public GameObject leftArrow;
    public GameObject rightArrow;

    public Animator avionAnimator;

    public Transform initialTransform;
    public Transform targetTransform;

    private float timeToPoint = 1f;

    public GameObject bulletObject;
    public GameObject pointObject;
    public float distanceBetweenBullets = 6f;

    private void Awake() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Start is called before the first frame update
    void Start() {
        avionAnimator = GetComponent<Animator>();
        initialTransform = middleTransform;
        targetTransform = middleTransform;

        Instantiate(bulletObject, middleTransform.position + Vector3.up * distanceBetweenBullets, bulletObject.transform.rotation);
        for (var i=1; i<50; i++) {
            var index = Random.Range(0, 4);
            if (i % 3 == 0) {
                if (index % 2 == 0) {
                    var xx = leftTransform.position.x + (middleTransform.position.x - leftTransform.position.x)/2;
                    Instantiate(pointObject, new Vector3(xx, middleTransform.position.y) + Vector3.up * distanceBetweenBullets * i, bulletObject.transform.rotation);
                }
                else {
                    var xx = middleTransform.position.x + (rightTransform.position.x - middleTransform.position.x)/2;
                    Instantiate(pointObject, new Vector3(xx, middleTransform.position.y) + Vector3.up * distanceBetweenBullets * i, bulletObject.transform.rotation);
                }
            }

            if (index == 0) {
                Instantiate(bulletObject, leftTransform.position + Vector3.up * distanceBetweenBullets * i, bulletObject.transform.rotation);
                Instantiate(bulletObject, middleTransform.position + Vector3.up * distanceBetweenBullets * i, bulletObject.transform.rotation);
            }
            else if (index == 1) {
                Instantiate(bulletObject, leftTransform.position + Vector3.up * distanceBetweenBullets * i, bulletObject.transform.rotation);
                Instantiate(bulletObject, rightTransform.position + Vector3.up * distanceBetweenBullets * i, bulletObject.transform.rotation);
            }
            else if (index == 2) {
                Instantiate(bulletObject, middleTransform.position + Vector3.up * distanceBetweenBullets * i, bulletObject.transform.rotation);
                Instantiate(bulletObject, rightTransform.position + Vector3.up * distanceBetweenBullets * i, bulletObject.transform.rotation);
            }
            else if (index == 3) {
                Instantiate(bulletObject, leftTransform.position + Vector3.up * distanceBetweenBullets * i, bulletObject.transform.rotation);
                Instantiate(bulletObject, middleTransform.position + Vector3.up * distanceBetweenBullets * i, bulletObject.transform.rotation);
                Instantiate(bulletObject, rightTransform.position + Vector3.up * distanceBetweenBullets * i, bulletObject.transform.rotation);
            }
        }
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

        avionAnimator.SetBool("shipRotating", shipRotating);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        gameController.StopTimer(false);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        gameController.StopTimer(true);
    }
}
