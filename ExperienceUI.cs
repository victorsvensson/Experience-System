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
    [SerializeField] private bool _playParticlesOnLevelUp;
    [SerializeField] private ParticleSystem levelUpParticles;
    [SerializeField] private bool _playSoundOnLevelUp;
    [SerializeField] private AudioSource levelUpSound;



    private void Start() {

        _experienceManager = FindObjectOfType<ExperienceManager>();

        _experienceManager.OnFunctionCalled += PlayExperienceParticles; // Subscribe to check if function runs in Experience Manager script
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

        if(_playParticlesOnLevelUp) levelUpParticles.Play();
    }

    public void PlayLevelUpSound() {
        try
        {
            if (_playSoundOnLevelUp) levelUpSound.Play();
        }
        catch
        {
            Debug.LogError("There's no audio source connected to the ExperienceUI script. Please attach an audio source to remove this message");
        }

    }

}
