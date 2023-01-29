using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameover : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    ScoreKeeper scoreKeeper;
    private void Awake()
    {
        scoreKeeper=FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        score.text="Your Score:\n"+scoreKeeper.GetScore().ToString();
    }

}
