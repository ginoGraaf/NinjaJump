using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI heightText;
    [SerializeField] TextMeshProUGUI coinNumberText;
    [SerializeField] Transform Player;
    [SerializeField] PlayerControl playerControl;
    private const int offsetStartpos=1;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        coinNumberText.text = playerControl.CoinCollect.ToString();
        heightText.text = ((int)Player.position.y+ offsetStartpos).ToString()+" M";
    }

   
}
