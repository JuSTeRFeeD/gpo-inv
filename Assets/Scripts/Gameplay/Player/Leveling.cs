using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Leveling : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lvlProgressTxt;
    [SerializeField] private TextMeshProUGUI lvlTxt;
    [SerializeField] private Image progressImg;

    public int Level { get; private set; } = 1;
    public int LevelExp { get; private set; } = 4;
    public int CurrentExp { get; private set; } = 0;

    private bool maxLvl = false;

    public void AddExp(int value)
    {
        if (maxLvl) return;
        CurrentExp += value;
        if (CurrentExp >= LevelExp)
        {
            Level++;
            if (Level >= 100)
            {
                maxLvl = true;
                lvlProgressTxt.text = "";
                progressImg.fillAmount = 1;
                return;
            }
            CurrentExp = CurrentExp - LevelExp > 0 ? CurrentExp - LevelExp : 0;
            LevelExp = Level * 4;
            lvlTxt.text = "Level: " + Level;
        }
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        lvlProgressTxt.text = CurrentExp + " / " + LevelExp;
        progressImg.fillAmount = (float)CurrentExp / (float)LevelExp;
    }

    private void Awake()
    {
        lvlTxt.text = "Level: " + Level;
        UpdateInfo();
    }
}
