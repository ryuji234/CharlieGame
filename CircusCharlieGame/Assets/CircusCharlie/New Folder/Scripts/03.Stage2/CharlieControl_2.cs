using UnityEngine;

public class CharlieControl_2 : MonoBehaviour
{
    Animator playerAni = default;
    public bool LeftMove = false;
    public bool RightMove = false;
    public bool Jump = false;
    public bool IsFinish = false;
    public float JumpPower;
    public GameObject gamemanager;
    Vector2 moveVelocity = Vector2.zero;

    private bool RingPass = false;
    private bool FirPortPass = false;
    private bool JumpRight = false;
    private bool JumpLeft = false;

    private Rigidbody2D playerRigidbody;
    private GameManager gameManager;
    float moveSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {

        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAni = GetComponent<Animator>();
        gameManager = gamemanager.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(playerRigidbody.position,Vector2.down, 1, LayerMask.GetMask("Platform"));

        //rayHit는 여러개 맞더라도 처음 맞은 오브젝트의 정보만을 저장(?) 
        if (IsFinish == false)
        {
            if (rayHit.collider != null)
            {
                
                if (RingPass)
                {
                    gameManager.AddRingScore();
                    RingPass = false;
                }
                if (FirPortPass)
                {
                    gameManager.AddFireportScore();
                    FirPortPass = false;
                }
                if (LeftMove)
                {

                    if (Camera.main.transform.localPosition.x > 0)
                    {
                        playerAni.SetBool("Move", true);
                        if (transform.localPosition.x > -390)
                        {
                            transform.Translate(Vector2.left * Time.deltaTime * (moveSpeed / 2));
                        }
                        else
                        {
                            Camera.main.transform.Translate(Vector2.left * Time.deltaTime * (moveSpeed / 2));
                        }

                    }

                    // transform.Translate(Vector2.left * Time.deltaTime * (moveSpeed/2));
                }
                if (RightMove)
                {
                    if (Camera.main.transform.localPosition.x < 141.7)
                    {

                        playerAni.SetBool("Move", true);
                        Camera.main.transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);

                    }
                    else
                    {

                        playerAni.SetBool("Move", true);
                        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);

                    }


                }
                if (LeftMove == false && RightMove == false)
                {
                    playerAni.SetBool("Move", false);
                }
                if (Jump || Input.GetKeyDown(KeyCode.Space))
                {
                    playerRigidbody.AddForce(Vector2.up * JumpPower);
                    JumpRight = RightMove;
                    JumpLeft = LeftMove;
                    Jump = false;
                }

            }
            else
            {

                if (JumpLeft)
                {

                    if (Camera.main.transform.localPosition.x > 0)
                    {
                        Camera.main.transform.Translate(Vector2.left * Time.deltaTime * (moveSpeed / 2));
                    }

                    //transform.Translate(Vector2.left * Time.deltaTime * (moveSpeed / 2));
                }
                if (JumpRight)
                {

                    if (Camera.main.transform.localPosition.x < 141.7)
                    {
                        Camera.main.transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
                    }
                    else
                    {
                        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
                    }

                }
                if (JumpLeft == false && JumpRight == false)
                {


                }
                playerAni.SetBool("Move", false);
                Jump = false;

            }
        }



    }
    public void Die()
    {

        playerAni.SetTrigger("Die");
        Time.timeScale = 0.01f;
        Invoke("Replay", 0.02f);

    }
    public void Finish()
    {
        playerAni.SetTrigger("Finish");
        gameManager.Isfinish = true;
        IsFinish = true;
        Invoke("NextStage", 8);
    }
    public void Replay()
    {
        CancelInvoke();
        Time.timeScale = 1f;
        GFunc.LoadScene(GData.SCENE_NAME_STAGE_2);
    }

    public void AddRingScore()
    {
        RingPass = true;
    }
    public void AddFirePortScore()
    {
        FirPortPass = true;
    }
    private void NextStage()
    {
        
    }
}
