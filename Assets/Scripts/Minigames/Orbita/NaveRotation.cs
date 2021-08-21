using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveRotation : MonoBehaviour
{
    [SerializeField] Texture2D cursor;
    [SerializeField] private Transform CannonTip;
    [SerializeField] private GameObject laserBlue16;
    //public float TimeToLive;

    public GameObject anchor;
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = 80f;
        Cursor.SetCursor(cursor, Vector3.zero, CursorMode.ForceSoftware);
            }

    // La nave mira el mouse y dispara
    void Update()
    {
        transform.RotateAround(anchor.transform.localPosition, Vector3.back, Time.deltaTime * velocidad);
        //transform.localRotation = Quaternion.Euler(0, 0, 0);
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }

        //destruye bala al cabo de 1 segundo
        //Object.Destroy(GameObject.FindWithTag("Bullet"), 1.0f);
    }
    //Instancia y mueve la bala
    private void FireBullet()
    {
        GameObject firedBullet = Instantiate(laserBlue16, CannonTip.position, CannonTip.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = CannonTip.up * 10f;

    }
}
