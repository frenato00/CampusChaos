using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField]
    public static int score;

    [SerializeField]
    private TextMeshProUGUI textScore;
    public static void IncreaseScore(int amount) {
        score+=amount;
        // text = GetComponent<TextMeshProUGUI>();
    }

    public static void ResetScore(){
        score=0;
    }
    public void Update(){
        textScore.text = "SCORE:"+score;
    }

}
