using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLeftArrow : MonoBehaviour {
    public AvionController avionController;
    private void Update() {
        transform.position = new Vector3(avionController.gameObject.transform.position.x - 1.5f, transform.position.y);
    }

    private void OnMouseDown() {
        if (!avionController.shipRotating) {
            if (avionController.initialTransform == avionController.rightTransform) {
                avionController.targetTransform = avionController.middleTransform;
            }
            if (avionController.initialTransform == avionController.middleTransform) {
                avionController.targetTransform = avionController.leftTransform;
            }

            avionController.leftArrow.SetActive(false);
            avionController.rightArrow.SetActive(false);

            avionController.shipRotating = true;
        }
    }
}