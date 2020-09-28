using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPass1 : MonoBehaviour
{
    public GameObject laserTrap;
    public GameObject boxChecker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Box") && boxChecker.GetComponent<BoxChecker1>().flag)
        {
            Destroy(other.gameObject);
            Destroy(laserTrap);
            //Destroy(gameObject);
        }
    }
}
