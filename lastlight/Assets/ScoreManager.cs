using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int score;
    public int Score { get => score; }

    void Update()
    {
        score += 1;
    }
}
