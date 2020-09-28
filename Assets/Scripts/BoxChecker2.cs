using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxChecker2 : MonoBehaviour
{
    public float minDistance;
    public GameObject gbBox3;
    public GameObject gbBox4;
    public bool flag = false;

    private Box box3;
    private Box box4;    

    // Start is called before the first frame update
    void Start()
    {
        box3 = gbBox3.GetComponent<Box>();
        box4 = gbBox4.GetComponent<Box>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gbBox3 != null && gbBox4 != null)
        {
            float distance = Vector3.Distance(box3.posRight.position, box4.posLeft.position);
            if (distance < minDistance && !flag)
            {
                flag = true;
                //设置父子对象
                Debug.Log("粘合起来啦！！！");
                Destroy(gbBox4.GetComponent<Rigidbody2D>());
                gbBox4.transform.position = new Vector3(gbBox3.transform.position.x + 0.8f, gbBox3.transform.position.y, 0);
                gbBox4.transform.parent = gbBox3.transform;
            }
        }
    }
}
