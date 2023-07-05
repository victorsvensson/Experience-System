using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeqDEV
{
    public class GiveExperience : MonoBehaviour
    {
        private ExperienceManager experienceManager;

        private bool _giveExperienceComplete;

        [SerializeField] private bool _GiveExperienceOnDeath;

        [Header("Make sure to add a Collider on this object using this option")]
        [Tooltip("Gives experience when hitting a collider. You can use collision or Is Trigger")]
        [SerializeField] private bool _GiveExperienceOnInteraction;

        [Space(10)]
        [SerializeField] private int _experience; // Amount of experience that should be given to player

        private void Start()
        {
            experienceManager = FindObjectOfType<ExperienceManager>();

            if(experienceManager == null)
            {
                Debug.Log("ExperienceManager does not exist on a Gameobject in the scene. Please add a gameobject that contains ExperienceManager for the script to work.");
            }
        }

        private void OnDestroy()
        {
            if (_GiveExperienceOnDeath) experienceManager.AddExperience(_experience);
            _giveExperienceComplete = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_GiveExperienceOnInteraction) experienceManager.AddExperience(_experience);
            _giveExperienceComplete = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_GiveExperienceOnInteraction) experienceManager.AddExperience(_experience);
            _giveExperienceComplete = true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_GiveExperienceOnInteraction) experienceManager.AddExperience(_experience);
            _giveExperienceComplete = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_GiveExperienceOnInteraction) experienceManager.AddExperience(_experience);
            _giveExperienceComplete = true;
        }
    }
}


