using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZeqDEV
{
    // This script is only used for testing in the demo scene.

    public class Demo : MonoBehaviour
    {
        ExperienceManager _experienceManager;

        public TMP_Text currentLevelText;
        public TMP_Text experienceText;
        public TMP_Text experienceUntilNextLevelText;

        private void Start()
        {
            _experienceManager = FindObjectOfType<ExperienceManager>();
        }

        private void Update()
        {
            try
            {
                currentLevelText.text = "Current level: " + _experienceManager.GetCurrentLevel().ToString();
                experienceText.text = "Current exp: " + _experienceManager.GetCurrentExperience().ToString();
                experienceUntilNextLevelText.text = "Exp until next level: " + _experienceManager.GetExperienceToNextLevel(_experienceManager.GetCurrentLevel()).ToString();
            }
            catch
            {
                Debug.LogError("Text components in Demo script is not attached to script. Please attach TMP_Text gameobject to demo script object");
            }

        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(0); // Load this scene
        }
    }
}


