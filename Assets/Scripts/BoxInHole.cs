using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInHole : MonoBehaviour
{
    public bool isInHole;
    // Start is called before the first frame update
    void Start()
    {
        isInHole = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            isInHole = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            isInHole = false;
        }
    }
}
