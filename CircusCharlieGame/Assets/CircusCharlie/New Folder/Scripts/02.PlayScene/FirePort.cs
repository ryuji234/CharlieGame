using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePort : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            CharlieControl player = other.GetComponent<CharlieControl>();
            player.Die();
        }
    }
}
