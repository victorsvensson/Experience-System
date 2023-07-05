using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO; // Used to save data into file
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

namespace ZeqDEV {

    [System.Serializable]
    public class ExperienceManager : MonoBehaviour
    {
        // Choose if you want to the save data into a file or in player prefabs. Not recommended to use both on the same time
        public bool saveToLocalFile;
        public bool saveToPrefabs;

        private int _currentLevel = 0;
        private int _experience = 0;
        [Header("Make sure Max Level and ExperiencePerLevel has same value")]
        [Space(10)]
        [SerializeField] private int maxLevel;
        [SerializeField] private int[] experiencePerLevel = new int[] { 100, 120, 140 };


        private void Start()
        {
            LoadData(); // Checks if there is any saved data to load
        }

        // Using a function to get current level to keep abstraction
        public int GetCurrentLevel() 
        {
            return _currentLevel;
        }

        // Using a function to get current experience to keep abstraction
        public int GetCurrentExperience()
        {
            return _experience;
        }

        public void AddExperience(int amount)
        {
            _experience += amount; // Add experience with chosen amount

            if(_experience >= GetExperienceToNextLevel(_currentLevel))
            {
                // Enough experience to level up. Level up!
                _experience -= GetExperienceToNextLevel(_currentLevel); // Subtract playerexperience with require experience
                _currentLevel++; // Increase the level when reaching max experience
            }
        }

        public int GetExperienceToNextLevel(int level)
        {
            if (level < experiencePerLevel.Length)
            {
                return experiencePerLevel[level]; // return the required experience to level up
            }
            else
            {
                // Level Invalid
                Debug.LogError("Level invalid: " + level);
                return _currentLevel;
            }
        }

        public void SaveData()
        {
            if(saveToLocalFile && saveToPrefabs)
            {
                Debug.LogError("Select either Save To File or Save to prefab");

            }else if(saveToLocalFile && !saveToPrefabs)
            {
                SaveSystem.SaveExperienceData(this);
                Debug.Log("Saved data local successful!");
            }
            else if(!saveToLocalFile && saveToPrefabs)
            {
                // Save to prefab code here
            }
        }

        public void LoadData()
        {
            if (saveToLocalFile && saveToPrefabs)
            {
                Debug.LogError("Select either Save To File or Save to prefab");
            }
            else if (saveToLocalFile && !saveToPrefabs)
            {

            }else if(!saveToLocalFile && saveToPrefabs)
            {

            }


            ExperienceData experienceData = SaveSystem.LoadExperience();

            if(experienceData != null)
            {
                _currentLevel = experienceData.currentLevel;
                _experience = experienceData.experience;

                Debug.Log("Loaded data successful");
            }
            else
            {
                Debug.Log("No saved data found");
            }
        }
    }
}


