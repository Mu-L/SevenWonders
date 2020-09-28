using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPassCheck : MonoBehaviour
{
    public Animator anim;
    public GameObject[] boxInHoles;
    public GameObject[] boxes;

    private bool stopCheckFlag;


    // Start is called before the first frame update
    void Start()
    {
        stopCheckFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopCheckFlag)
        {
            for (int i = 0; i < boxInHoles.Length; i++)
            {
                if (!boxInHoles[i].GetComponent<BoxInHole>().isInHole)
                {
                    break;
                }

                if (i == boxInHoles.Length - 1)
                {
                    //设置Flag
                    stopCheckFlag = true;
                    //播放平台消失动画
                    anim.SetTrigger("Hide");
                    //删除箱子
                    //删除洞里的箱子示意图
                    //删除平台
                }
            }
        }
    }

    void DestroyBox()
    {
        foreach(GameObject gb in boxes)
        {
            Destroy(gb);
        }
    }

    void DestroyBoxInHole()
    {
        foreach (GameObject gb in boxInHoles)
        {
            Destroy(gb);
        }
    }

    void DestroyLevelPass()
    {
        Destroy(gameObject);
    }
}
