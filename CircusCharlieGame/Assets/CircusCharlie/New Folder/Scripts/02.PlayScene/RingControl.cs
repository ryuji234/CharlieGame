using UnityEngine;

public class RingControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime);
    }
    public void DestroyRing()
    {
        BigRingPool.ReturnObject(this);
        CancelInvoke();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        
        if (other.tag == "End")
        {
            Invoke("DestroyRing", 0);
        }
        if(other.tag == "Player")
        {
            CharlieControl player = other.GetComponent<CharlieControl>();
            LionControl lion = player.GetComponentInChildren<LionControl>();
            player.Die();
            lion.Die();
        }
    }
}
