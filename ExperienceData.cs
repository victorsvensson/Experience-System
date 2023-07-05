using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace ZeqDEV {

    // We have to use this to separate the variables that's going to be saved from ExperienceManager into this class
    // The reason is because you cannot serialize a class that uses Monobehavior

    [System.Serializable] // Set this class to being able to be serialized (saved)
    public class ExperienceData {

    // The variables that's going to be saved. You can add more variables here but make sure you also add it in ExperienceManager and also in the constructor below.
    public int currentLevel;
    public int experience;


        public ExperienceData(ExperienceManager experienceManager) // Constructor
        {
            currentLevel = experienceManager.GetCurrentLevel(); // Get the values thats going to be saved from ExperienceManager
            experience = experienceManager.GetCurrentExperience(); // Get the values thats going to be saved from ExperienceManager
        }
    }
}
