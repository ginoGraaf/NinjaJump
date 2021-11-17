using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    int height = 0;
    int coins = 0;
    int bonsiaCollect = 0;
    int totalScore = 0;
    [SerializeField]
    [Range(1,200)]
    int multipleBonsiaScore;



    public void GameOver()
    {
        CountScore();
    }

    public void CountScore()
    {
        totalScore = (bonsiaCollect * multipleBonsiaScore) + coins + height;
    }
}
