using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

namespace ZeqDEV
{
    public class ExperienceUI : MonoBehaviour
    {
        private ExperienceManager _experienceManager;
        private AudioSource _levelUpSound;

        [SerializeField] private TMP_Text _experienceText;
        [SerializeField] private TMP_Text _currentLevelText;
        [SerializeField] private TMP_Text _totalExperienceCurrentLevelText;
        [SerializeField] private Slider _experienceBar;
        [SerializeField] private bool _playParticlesOnLevelUp;
        [SerializeField] private ParticleSystem levelUpParticles;
        [SerializeField] private bool _playSoundOnLevelUp;

        private void Start()
        {

            _experienceManager = FindObjectOfType<ExperienceManager>();
            _levelUpSound = GetComponent<AudioSource>();

            _experienceManager.OnFunctionCalled += PlayExperienceParticles; // Subscribe to check if function runs in Experience Manager script
            _experienceManager.OnFunctionCalled += PlayLevelUpSound; // Subscribe to check if function runs in Experience Manager script
        }

        private void Update()
        {

            // Using try catch function to avoid getting errors if you dont use all the functions
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

        void ShowExperienceText()
        {
            _experienceText.text = _experienceManager.GetCurrentExperience().ToString();
        }

        void ShowCurrentLevelText()
        {
            _currentLevelText.text = _experienceManager.GetCurrentLevel().ToString();
        }

        void ShowTotalExperienceCurrentLevel()
        {
            _totalExperienceCurrentLevelText.text = _experienceManager.TotalExperienceCurrentLevel().ToString();
        }

        void ShowExperienceBar()
        {

            _experienceBar.value = _experienceManager.GetCurrentExperience();
            _experienceBar.maxValue = _experienceManager.GetExperienceToNextLevel(_experienceManager.GetCurrentLevel());
        }

        public void PlayExperienceParticles()
        {

            if (_playParticlesOnLevelUp) levelUpParticles.Play();
        }

        public void PlayLevelUpSound()
        {
            try
            {
                if (_playSoundOnLevelUp) _levelUpSound.Play();
            }
            catch
            {
                Debug.LogError("There's no audio source connected to the ExperienceUI script. Please attach an audio source to remove this message");
            }

        }

    }
}


