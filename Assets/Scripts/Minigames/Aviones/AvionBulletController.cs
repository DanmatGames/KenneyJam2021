using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvionBulletController : MonoBehaviour
{
    public float bulletSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - bulletSpeed * Time.deltaTime);
    }
}