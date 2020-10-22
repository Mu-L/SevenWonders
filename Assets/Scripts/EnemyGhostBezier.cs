using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhostBezier : MonoBehaviour
{
    public int health;
    public int damage;
    public Transform[] routes;

    private int routeToGo;
    public float speed;
    private float t;
    private Vector2 ghostPos;
    private bool coroutineAllowed;
    private bool goAhead;

    private PlayerHealth playerHealth;

    // Use this for initialization
    void Start()
    {
        routeToGo = 0;
        t = 0f;
        coroutineAllowed = true;
        goAhead = true;

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameObject g1 = transform.GetChild(0).gameObject;
            transform.GetChild(0).parent = transform.parent;            
            g1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            //GameObject objectToDelete = transform.parent;
            //transform.parent = null;
            //GameObject.Destroy(objectToDelete);
            Destroy(gameObject);
        }
        else
        {
            if (coroutineAllowed)
            {
                StartCoroutine(GoByRoute(routeToGo));
            }
        }        
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
    }

    IEnumerator GoByRoute(int routeNumber)
    {
        coroutineAllowed = false;
        if(goAhead)
        {
            Vector2 p0 = routes[routeNumber].GetChild(0).position;
            Vector2 p1 = routes[routeNumber].GetChild(1).position;
            Vector2 p2 = routes[routeNumber].GetChild(2).position;
            Vector2 p3 = routes[routeNumber].GetChild(3).position;

            while (t < 1)
            {
                t += speed * Time.deltaTime;
                ghostPos = p0 * Mathf.Pow(1 - t, 3) +
                    3 * p1 * Mathf.Pow(1 - t, 2) * t +
                    3 * p2 * (1 - t) * Mathf.Pow(t, 2) +
                    p3 * Mathf.Pow(t, 3);
                transform.position = ghostPos;
                yield return new WaitForEndOfFrame();
            }

            t = 0f;
            routeToGo += 1;

            if (routeToGo > routes.Length - 1)
            {
                routeToGo = routes.Length - 1;
                goAhead = false;
            }
        }   
        else
        {
            Vector2 p0 = routes[routeNumber].GetChild(3).position;
            Vector2 p1 = routes[routeNumber].GetChild(2).position;
            Vector2 p2 = routes[routeNumber].GetChild(1).position;
            Vector2 p3 = routes[routeNumber].GetChild(0).position;

            while (t < 1)
            {
                t += speed * Time.deltaTime;
                ghostPos = p0 * Mathf.Pow(1 - t, 3) +
                    3 * p1 * Mathf.Pow(1 - t, 2) * t +
                    3 * p2 * (1 - t) * Mathf.Pow(t, 2) +
                    p3 * Mathf.Pow(t, 3);
                transform.position = ghostPos;
                yield return new WaitForEndOfFrame();
            }

            t = 0f;
            routeToGo -= 1;

            if (routeToGo < 0)
            {
                routeToGo = 0;
                goAhead = true;
            }
        }

        coroutineAllowed = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);
            }
        }
    }
}
