using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    GameObject Charlie;
    CharlieControl charlieControl;
    CharlieControl_2 charlieControl_2;
    LionControl lion;
    // Start is called before the first frame update
    void Start()
    {
        Charlie = GameObject.Find("Charlie");
        charlieControl = Charlie.GetComponent<CharlieControl>();
        charlieControl_2 = Charlie.GetComponent<CharlieControl_2>();
        lion= Charlie.GetComponentInChildren<LionControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LeftBtnDown()
    {
        if(charlieControl !=null)
        {
            charlieControl.LeftMove = true;
            lion.LeftMove = true;
        }
        if(charlieControl_2 != null)
        {
            charlieControl_2.LeftMove = true;
        }
        
        
    }
    public void LeftBtnUp()
    {
        if (charlieControl != null)
        {
            charlieControl.LeftMove = false;
            lion.LeftMove = false;
        }
        if (charlieControl_2 != null)
        {
            charlieControl_2.LeftMove = false;
        }

    }
    public void RightBtnDown()
    {
        if (charlieControl != null)
        {
            charlieControl.RightMove = true;
            lion.RightMove = true;
        }
        if (charlieControl_2 != null)
        {
            
            charlieControl_2.RightMove = true;

        }

    }
    public void RightBtnUp()
    {
        if (charlieControl != null)
        {
            charlieControl.RightMove = false;
            lion.RightMove = false;
        }
        if (charlieControl_2 != null)
        {
            charlieControl_2.RightMove = false;
        }

    }
    public void JumpBtnClick()
    {
        if(charlieControl != null)
        {
            charlieControl.Jump = true;
        }
        if(charlieControl_2 != null)
        {
            charlieControl_2.Jump = true;
        }
        
    }
}
