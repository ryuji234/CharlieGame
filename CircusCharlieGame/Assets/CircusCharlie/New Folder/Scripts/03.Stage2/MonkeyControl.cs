using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyControl : MonoBehaviour
{
    protected bool IsStop;

    void Start()
    {
        IsStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsStop)
        {
            //transform.Translate(transform.position);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }
    }
    public void DestroyMonkey()
    {
        MonkeyPool.ReturnObject(this);
        CancelInvoke();
    }
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "End")
        {
            Invoke("DestroyMonkey", 0);
        }
        if (other.tag == "Player")
        {
            CharlieControl_2 player = other.GetComponent<CharlieControl_2>();
            
            player.Die();
            
        }
    }
    
}
