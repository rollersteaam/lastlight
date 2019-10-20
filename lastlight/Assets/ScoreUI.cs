using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text scoreText;
    ScoreManager score;

    void Start()
    {
        score = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    void Update()
    {
        scoreText.text = score.Score.ToString();
    }
}
