using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using ZeqDEV;
using System;
using System.Linq.Expressions;

public class ExperienceUI : MonoBehaviour
{
    private ExperienceManager _experienceManager;

    [SerializeField] private TMP_Text _experienceText;
    [SerializeField] private TMP_Text _currentLevelText;
    [SerializeField] private TMP_Text _totalExperienceCurrentLevelText;
    [SerializeField] private Slider _experienceBar;
    [SerializeField] private ParticleSystem levelUpParticles;

    private void Start() {

        _experienceManager = FindObjectOfType<ExperienceManager>();
    }

    private void Update() {
        try
        {
            ShowExperienceText();
        }
        catch { }
        try
        {
            ShowCurrentLevelText();
        }
        catch { }
        try
        {
            ShowTotalExperienceCurrentLevel();
        }
        catch { }
        try
        {
            ShowExperienceBar();
        }
        catch { }
        try
        {
            ShowExperienceBar();
        }
        catch { }
    }

    void ShowExperienceText() {
        _experienceText.text = _experienceManager.GetCurrentExperience().ToString();
    }

    void ShowCurrentLevelText() {
        _currentLevelText.text = _experienceManager.GetCurrentLevel().ToString();
    }

    void ShowTotalExperienceCurrentLevel() {
        _totalExperienceCurrentLevelText.text = _experienceManager.TotalExperienceCurrentLevel().ToString();
    }

    void ShowExperienceBar() {

        _experienceBar.value = _experienceManager.GetCurrentExperience();
        _experienceBar.maxValue = _experienceManager.GetExperienceToNextLevel(_experienceManager.GetCurrentLevel());
    }

    public void PlayExperienceParticles() {

        levelUpParticles.Play();
    }

}
