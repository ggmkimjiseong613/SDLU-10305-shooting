using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManger : MonoBehaviour
{
    public Text currentScoreUI;
    public int currentScore = 0;
    public Text bestScoreUI;
    public int bestScore = 0;


    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "최고 점수 : " + bestScore;
    }
}
