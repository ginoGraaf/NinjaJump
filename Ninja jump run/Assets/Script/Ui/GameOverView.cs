using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOverView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI heightScore;
    [SerializeField] private TextMeshProUGUI coinScore;
    [SerializeField] private TextMeshProUGUI totalScore;
    [SerializeField] private GameObject GameoverPannel;

    private const int offsetStartpos = 1;
    public void GameOver(PlayerControl playercontrol)
    {
        GameoverPannel.SetActive(true);
        int totalHeight = (int)playercontrol.transform.position.y + offsetStartpos;
        heightScore.text = totalHeight.ToString();
        coinScore.text = playercontrol.CoinCollect.ToString();
        totalScore.text = (totalHeight + (playercontrol.CoinCollect * 100)).ToString();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
