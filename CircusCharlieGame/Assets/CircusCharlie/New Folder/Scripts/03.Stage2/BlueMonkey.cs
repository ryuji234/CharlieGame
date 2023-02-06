
using Unity.VisualScripting;
using UnityEngine;

public class BlueMonkey : MonoBehaviour
{
    private Animator BlueMonkeyAni;
    private Rigidbody2D playerRigidbody;
    private const float JUMPPOWER = 300;
    
    
    private bool IsJump = false;
    private bool Jumping = false;
    // Start is called before the first frame update
    void Start()
    {
        BlueMonkeyAni = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (IsJump)
        {
            Jumping= true;
            BlueMonkeyAni.SetBool("Jump", Jumping);
            playerRigidbody.AddForce(Vector2.up * JUMPPOWER);
            IsJump = false;

        }
        else
        {
            BlueMonkeyAni.SetBool("Jump", Jumping);
            transform.Translate(Vector2.left * Time.deltaTime*3);
        }

    }
    public void DestroyMonkey()
    {
        BlueMonkeyPool.ReturnObject(this);
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
        if (other.tag == "Monkey")
        {
            
            
            
            IsJump = true;
        }
        if(other.tag =="Ground")
        {
            Jumping= false;
        }
    }


}
