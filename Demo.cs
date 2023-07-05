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
        [SerializeField] ExperienceManager experienceManager;

        public TMP_Text currentLevelText;
        public TMP_Text experienceText;
        public TMP_Text experienceUntilNextLevelText;

        private void Start()
        {
            experienceManager = FindObjectOfType<ExperienceManager>();
        }

        private void Update()
        {
            try
            {
                currentLevelText.text = "Current level: " + experienceManager.GetCurrentLevel().ToString();
                experienceText.text = "Current exp: " + experienceManager.GetCurrentExperience().ToString();
                experienceUntilNextLevelText.text = "Exp until next level: " + experienceManager.GetExperienceToNextLevel(experienceManager.GetCurrentLevel()).ToString();
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


