using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeqDEV
{
    public class GiveExperience : MonoBehaviour
    {
        private ExperienceManager experienceManager;

        private bool _giveExperienceComplete;

        [Header("When object is destroyed or when an enemy dies use this option")]
        [SerializeField] private bool _GiveExperienceOnDestroy;

        [Header("Make sure to add a Collider with Is Trigger active on this object using this option")]
        [Tooltip("Gives experience when hitting a collider. You can use collision or Is Trigger")]
        [SerializeField] private bool _giveExperienceOnColliderTrigger;

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

        // Gives experience when the gameobject is destroyed (For example when an enemy dies)
        private void OnDestroy()
        {
            if (_GiveExperienceOnDestroy) experienceManager.AddExperience(_experience);
        }

        // Gives experience if this gameobject has 2D Collider component attached with Is Trigger active
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_giveExperienceOnColliderTrigger) experienceManager.AddExperience(_experience);
        }

        // Gives experience if this gameobject has a Collider component attached with Is Trigger active
        private void OnTriggerEnter(Collider other)
        {
            if (_giveExperienceOnColliderTrigger) experienceManager.AddExperience(_experience);
        }
    }
}


