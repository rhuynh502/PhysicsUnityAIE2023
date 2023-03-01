using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textDeath;
    [SerializeField] TextMeshProUGUI textTime;

    private float deaths = 0;
    private float time = 0;
    private int minutes = 0;
    private int seconds = 0;

    private void Awake()
    {
        textDeath.text = "Deaths: " + deaths;
    }

    void Update()
    {
        time += Time.deltaTime;
        minutes = (int)(time / 60);
        seconds = (int)(time % 60);
        textTime.text = minutes+ ":" + seconds;
    }

    public void AddDeathCount()
    {
        deaths++;
        textDeath.text = "Deaths: " + deaths;
    }
}
