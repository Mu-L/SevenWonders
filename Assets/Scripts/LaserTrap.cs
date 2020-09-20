using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    public GameObject playerRespawn;
    public Transform respawnPos;    

    //private GameObject playerToDead;
    // Start is called before the first frame update
    void Start()
    {
        //playerToDead = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            Destroy(other.gameObject);
            GameObject playerObj = Instantiate(playerRespawn, respawnPos.position, Quaternion.identity);
            GameController.camFollow.target = playerObj.transform;
        }
    }
}
