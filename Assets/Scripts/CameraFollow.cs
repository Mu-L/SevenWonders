using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 minPostion;
    public Vector2 maxPostion;

    // Start is called before the first frame update
    void Start()
    {
//#if UNITY_STANDALONE_OSX
//        Screen.SetResolution(2688, 1536, false);
//#elif UNITY_STANDALONE_WIN
//        Screen.SetResolution(1344, 768, false); 
//#elif UNITY_STANDALONE_LINUX
//        Screen.SetResolution(1344, 768, false);
//#endif
        GameController.player = GameObject.FindGameObjectWithTag("Player");
        GameController.camFollow = GameObject.FindGameObjectWithTag("CameraFollow").GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
                targetPos.x = Mathf.Clamp(targetPos.x, minPostion.x, maxPostion.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPostion.y, maxPostion.y);
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }

    public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
    {
        minPostion = minPos;
        maxPostion = maxPos;
    }
}
