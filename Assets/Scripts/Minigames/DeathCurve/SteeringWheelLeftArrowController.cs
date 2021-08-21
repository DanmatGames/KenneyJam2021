using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelLeftArrowController : MonoBehaviour
{
    private GameObject car;
    private SteeringWheelRightArrowController rightController;
    private MinigameDeathCurveController minigameController;

    public bool canDrive = true;

    private void Start()
    {
        car = GameObject.FindGameObjectWithTag("car");
        rightController = this.transform.parent.GetChild(1).GetComponent<SteeringWheelRightArrowController>();
        minigameController = GameObject.FindGameObjectWithTag("minigameController").GetComponent<MinigameDeathCurveController>();
    }

    private void OnMouseDown()
    {
        if (this.canDrive)
        {
            if (minigameController.direction == Vector3.up)
            {
                car.transform.rotation = Quaternion.Euler(car.transform.rotation.x, car.transform.rotation.y, 90f);
                minigameController.direction = Vector3.left;
            }
            else if (minigameController.direction == Vector3.down)
            {
                car.transform.rotation = Quaternion.Euler(car.transform.rotation.x, car.transform.rotation.y, -90f);
                minigameController.direction = Vector3.right;
            }
            else
            {
                if (minigameController.direction == Vector3.right)
                {
                    car.transform.rotation = Quaternion.Euler(car.transform.rotation.x, car.transform.rotation.y, 0);
                    minigameController.direction = Vector3.up;
                }
                else if (minigameController.direction == Vector3.left)
                {
                    car.transform.rotation = Quaternion.Euler(car.transform.rotation.x, car.transform.rotation.y, 180);
                    minigameController.direction = Vector3.down;
                }
            }

            this.canDrive = false;
            rightController.canDrive = false;
        }
    }
}
