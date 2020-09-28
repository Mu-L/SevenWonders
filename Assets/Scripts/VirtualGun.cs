using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualGun : MonoBehaviour
{
    public GameObject bullet;
    public Transform gunHole;
    public Camera cam;
    public float upForce;

    public float intervalTime1;
    public float intervalTime2;

    private Vector3 mousePos;
    private Vector2 gunDirection;

    private Rigidbody2D playerRb2d;

    // Start is called before the first frame update
    void Start()
    {
        playerRb2d = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        gunDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        //if (Input.GetMouseButtonDown(0))
        //{
        //    //Debug.Log("鼠标左键已经按下");
        //    //生成一颗子弹
        //    Instantiate(bullet, gunHole.position, Quaternion.Euler(transform.eulerAngles));
        //}
    }

    public void Shoot3()
    {
        Shoot();
        Invoke("Shoot", intervalTime1);
        Invoke("Shoot", intervalTime2);
    }

    public void Shoot()
    {
        Instantiate(bullet, gunHole.position, Quaternion.Euler(transform.eulerAngles));
        //Vector2 dir = new Vector2(-gunHole.position.x, -gunHole.position.y);
        playerRb2d.velocity = -gunDirection.normalized * upForce;
    }


}
