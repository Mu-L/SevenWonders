using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDust : MonoBehaviour
{
    public static Animator Anim;
    private BoxCollider2D bx2d;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        bx2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnableBoxCollider2d()
    {
        bx2d.enabled = true;
    }

    void DisableBoxCollider2d()
    {
        bx2d.enabled = false;
    }
}
