using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Transform posUp;
    public Transform posDown;
    public Transform posLeft;
    public Transform posRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("posUp:" + posUp.position);
        //Debug.Log("posDown:" + posDown.position);
        //Debug.Log("posLeft:" + posLeft.position);
        //Debug.Log("posRight:" + posRight.position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Box") && other.GetType().ToString() == "UnityEngine.EdgeCollider2D")
        {
            Debug.Log("碰撞成功");
            transform.parent = other.gameObject.transform;
        }
    }
}
