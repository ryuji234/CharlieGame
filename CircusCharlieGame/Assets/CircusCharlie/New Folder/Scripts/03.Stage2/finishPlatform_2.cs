using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishPlatform_2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CharlieControl_2 player = other.GetComponent<CharlieControl_2>();
            player.Finish();
        }
    }
}
