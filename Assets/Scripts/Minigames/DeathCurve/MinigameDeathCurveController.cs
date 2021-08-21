using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameDeathCurveController : MonoBehaviour
{
    public GameObject straightRoad;
    public GameObject curvedRoad;
    public GameObject car;
    public GameObject controller;
    public GameObject spawnPoints;

    public Vector3 direction;

    private GameObject carInstantiated;

    // Start is called before the first frame update
    void Start()
    {
        //Número random que decide en que respawn aparecera la carretera/coche
        int spawnPoint = Random.Range(0, 12);

        //Inicializa el transform del spawnPoint
        Transform spawnPointTransform = spawnPoints.transform.GetChild(spawnPoint).transform;

        //Instancia straightRoad
        Instantiate(straightRoad, spawnPointTransform);

        //Position del curvedRoad
        Vector3 curvedRoadPosition;
        if (spawnPoint >= 0 && spawnPoint <= 3)
        {
            curvedRoadPosition = new Vector3(
                spawnPointTransform.position.x,
                spawnPointTransform.position.y - 5,
                spawnPointTransform.position.z
            );
        }
        else if (spawnPoint >= 6 && spawnPoint <= 9)
        {
            curvedRoadPosition = new Vector3(
                spawnPointTransform.position.x,
                spawnPointTransform.position.y + 5,
                spawnPointTransform.position.z
            );
        }
        else if (spawnPoint == 4 || spawnPoint == 5)
        {
            curvedRoadPosition = new Vector3(
                spawnPointTransform.position.x + 5,
                spawnPointTransform.position.y,
                spawnPointTransform.position.z
            );
        }
        else
        {
            curvedRoadPosition = new Vector3(
                spawnPointTransform.position.x - 5,
                spawnPointTransform.position.y,
                spawnPointTransform.position.z
            );
        }

        //Orientación x/y del curvedRoad
        float rotationY = 0f;
        float rotationX = 0f;
        if (spawnPoint == 0 || spawnPoint == 11)
        {
            rotationX = 180f;
            rotationY = 0f;
        }
        else if (spawnPoint == 1 || spawnPoint == 2)
        {
            rotationX = 180f;
            int randomOrientation = Random.Range(0, 2);
            if (randomOrientation == 0) rotationY = 0f;
            else if (randomOrientation == 1) rotationY = 180f;
        }
        else if (spawnPoint == 7 || spawnPoint == 8)
        {
            rotationX = 0f;
            int randomOrientation = Random.Range(0, 2);
            if (randomOrientation == 0) rotationY = 0f;
            else if (randomOrientation == 1) rotationY = 180f;
        }
        else if (spawnPoint == 3 || spawnPoint == 4 || spawnPoint == 10)
        {
            rotationX = 180f;
            rotationY = 180f;
        }
        else if (spawnPoint == 9 || spawnPoint == 5)
        {
            rotationX = 0f;
            rotationY = 180f;
        }
        else
        {
            rotationX = 0f;
            rotationY = 0f;
        }



        //Orientación z de curvedRoad y recogemos si se trata de un spawn izquierdo o derecho
        string hSide = "false";
        float rotationZ = 0f;
        if (spawnPoint == 4 || spawnPoint == 5 || spawnPoint == 11)
        {
            rotationZ = 90f;
            if (spawnPoint == 11) hSide = "right";
            else hSide = "left";
        }
        else if (spawnPoint == 10)
        {
            rotationZ = -90f;
            hSide = "right";
        }

        //Instancia curvedRoad
        Instantiate(
        curvedRoad,
        curvedRoadPosition,
        Quaternion.Euler(rotationX, rotationY, rotationZ)
        );

        //Position de car
        Vector3 carPosition = new Vector3(
                spawnPointTransform.position.x,
                spawnPointTransform.position.y,
                spawnPointTransform.position.z
            );

        //Instancia car
        carInstantiated = Instantiate(car, carPosition, Quaternion.Euler(rotationX, rotationY, rotationZ));

        //Instancia el volante con las flechas
        Instantiate(controller, spawnPointTransform.transform.GetChild(0).transform);

        //Dirección a la que se movera el coche
        switch (hSide, rotationX, rotationZ)
        {
            case ("false", 180, 0):
                direction = Vector3.down;
                break;
            case ("false", 0, 0):
                direction = Vector3.up;
                break;
            case ("left", 0, 90):
                direction = Vector3.right;
                break;
            case ("left", 180, 90):
                direction = Vector3.right;
                break;
            case ("right", 180, 90):
                direction = Vector3.left;
                break;
            case ("right", 180, -90):
                direction = Vector3.left;
                break;
        }
    }
}
