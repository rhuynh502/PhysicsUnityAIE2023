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
    public bool win = false;

    private void Awake()
    {
        textDeath.text = "Deaths: " + deaths;
        time = 0;
    }

    void Update()
    {
        if (CharacterMovement.isPaused) return;

        if(!win)
            time += Time.deltaTime;
        minutes = (int)(time / 60);
        seconds = (int)(time % 60);
        textTime.text = minutes+ ":" + seconds.ToString("D2");
    }

    public void AddDeathCount()
    {
        deaths++;
        textDeath.text = "Deaths: " + deaths;
    }
}
