using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Score;
    public GameObject HighScore;
    public GameObject Bonus;

    private int BonusScore = 5000;
    private int Highscore = 20000;
    public bool Isfinish = false;
    void Start()
    {
        Bonus.SetTmpText($"BONUS - {BonusScore}");
        HighScore.SetTmpText($"HI - {Highscore:D6}");
    }

    void Update()
    {
        if(Isfinish)
        {
            Score.SetTmpText($"{GData.gameScore:D7}");
            Bonus.SetTmpText($"BONUS - {BonusScore}");
            if(BonusScore > 0)
            {
                Invoke("ScoreCount", 0.1f);
            }
            else
            {
                
            }
        }
        else
        {
            Score.SetTmpText($"{GData.gameScore:D7}");
            Bonus.SetTmpText($"BONUS - {BonusScore}");
            Invoke("BonusCount", 0.5f);
        }
    }
    private void BonusCount()
    {
        CancelInvoke();
        BonusScore -= 10;
    }
    private void ScoreCount()
    {
        CancelInvoke();
        if(BonusScore >100)
        {
            GData.gameScore += 100;
            BonusScore -= 100;
        }
        else
        {
            GData.gameScore += BonusScore;
            BonusScore -= BonusScore;
        }
    }

    public void AddRingScore()
    {
        GData.gameScore += 100;
    }
    public void AddFireportScore()
    {
        GData.gameScore += 300;
    }
}
