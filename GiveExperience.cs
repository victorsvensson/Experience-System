using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GiveExperience : MonoBehaviour
{
    private ExperienceManager experienceManager;
    private bool isSceneReloading = false;

    [Header("When object is destroyed or when an enemy dies use this option")]
    [SerializeField] private bool _GiveExperienceOnDestroy;

    [Header("Make sure to add a Collider with Is Trigger active on this object using this option")]
    [Tooltip("Gives experience when hitting a collider. You can use collision or Is Trigger")]
    [SerializeField] private bool _giveExperienceOnColliderTrigger;
    private bool _collected; // to prevent player to keep getting experience when colliding with object

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
        if (gameObject.scene.isLoaded)
        {
            if (_GiveExperienceOnDestroy) experienceManager.AddExperience(_experience);
        }
    }

    // Gives experience if this gameobject has 2D Collider component attached with Is Trigger active
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_giveExperienceOnColliderTrigger && _collected)
        {
            experienceManager.AddExperience(_experience);
            _collected = true;
        }
    }

    // Gives experience if this gameobject has a Collider component attached with Is Trigger active
    private void OnTriggerEnter(Collider other)
    {
        if (_giveExperienceOnColliderTrigger && _collected)
        {
            experienceManager.AddExperience(_experience);
            _collected = true;
        }
    }

/*    private void OnEnable() {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable() {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneUnloaded(Scene scene) {
        isSceneReloading = true;
    }*/
}



