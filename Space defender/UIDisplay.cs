using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI scoreText;
    [SerializeField]Slider healthSlider;
    ScoreKeeper scoreKeeper;
    [SerializeField]Health healthScript;

    void Awake()
    {
        scoreKeeper=FindObjectOfType<ScoreKeeper>();
    }
    private void Start()
    {
        healthSlider.maxValue = healthScript.GetHealth();
    }


    void Update()
    {
        DisplayingScore();
        SliderConfig();
    }
    void DisplayingScore()
    {
        scoreText.text =scoreKeeper.GetScore().ToString("00000000");
    }
    void SliderConfig()
    {
        healthSlider.value = healthScript.GetHealth();
    }
        
}
