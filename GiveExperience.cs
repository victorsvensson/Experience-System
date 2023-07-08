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

        // Gives experience when the gameobject is destroyed
        private void OnDestroy()
        {
            if (_GiveExperienceOnDeath) experienceManager.AddExperience(_experience);
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

        //// Gives experience if the gameobject has a Collider component attached with Is Trigger disabled
        //private void OnCollisionEnter(Collision collision)
        //{
        //    if (_giveExperienceOnCollision) experienceManager.AddExperience(_experience);
        //}

        //// Gives experience if the gameobject has a 2D Collider component attached with Is Trigger disabled
        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    if (_giveExperienceOnCollision) experienceManager.AddExperience(_experience);
        //}

        
    }
}


