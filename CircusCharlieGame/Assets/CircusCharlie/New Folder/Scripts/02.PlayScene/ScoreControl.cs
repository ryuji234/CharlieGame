using UnityEngine;

public class ScoreControl : MonoBehaviour
{
    public GameObject Player;
    CharlieControl player;
    CharlieControl_2 player_2;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.GetComponent<CharlieControl>();
        player_2 = Player.GetComponent<CharlieControl_2>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ring" || other.tag == "Monkey")
        {
            if (player != null)
            {
                player.AddRingScore();
            }
            if(player_2 != null)
            {
                player_2.AddRingScore();
            }
        }
        if (other.tag == "FirePort")
        {
            player.AddFirePortScore();
        }
    }
}
