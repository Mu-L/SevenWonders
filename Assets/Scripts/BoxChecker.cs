using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxChecker : MonoBehaviour
{
    public float minDistance;
    public GameObject gbBox1;
    public GameObject gbBox2;
    public bool flag1 = false;

    private Box box1;
    private Box box2;
    

    // Start is called before the first frame update
    void Start()
    {
        //box1 = GameObject.Find("Box1").GetComponent<Box>();
        //box2 = GameObject.Find("Box2").GetComponent<Box>();

        box1 = gbBox1.GetComponent<Box>();
        box2 = gbBox2.GetComponent<Box>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gbBox1 != null && gbBox2 != null)
        {
            float distance = Vector3.Distance(box1.posUp.position, box2.posDown.position);
            if (distance < minDistance && !flag1)
            {
                flag1 = true;
                //设置父子对象
                Debug.Log("粘合起来啦！！！");
                Destroy(gbBox2.GetComponent<Rigidbody2D>());
                gbBox2.transform.position = new Vector3(gbBox1.transform.position.x, gbBox1.transform.position.y + 0.8f, 0);
                gbBox2.transform.parent = gbBox1.transform;

                //StartCoroutine(LockBox());
            }
        }
    }

    IEnumerator LockBox()
    {
        yield return new WaitForSeconds(0.1f);
        
        
    }
}
