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

        private void Start()
        {
            _experienceManager = FindObjectOfType<ExperienceManager>();
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(0); // Load this scene
        }
    }
}


