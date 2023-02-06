using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LionControl : MonoBehaviour
{
    Animator lionAni = default;
    public bool LeftMove = false;
    public bool RightMove = false;
    public bool Jump = false;

    // Start is called before the first frame update
    void Start()
    {
        lionAni = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position,Vector2.down, 1, LayerMask.GetMask("Platform"));
        if (rayHit.collider != null)
        {
            lionAni.SetBool("Jump", false);
            if (LeftMove)
            {
                lionAni.SetBool("Move", true);
            }
            if (RightMove)
            {
                lionAni.SetBool("Move", true);
            }
           
            if (LeftMove == false && RightMove == false)
            {
                lionAni.SetBool("Move", false);
            }
        }
        else
        {
            lionAni.SetBool("Jump", true);
        }
       
    }
    public void Die()
    {
        lionAni.SetTrigger("Die");
    }
}
