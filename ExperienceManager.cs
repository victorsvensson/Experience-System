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

        [SerializeField] private int _currentLevel = 0;
        [SerializeField] private int _experience = 0;
        [Header("Make sure Max Level and ExperiencePerLevel has same value")]
        [Space(10)]
        [SerializeField] private int maxLevel;
        [SerializeField] private int[] experiencePerLevel = new int[] { };

        private void Start()
        {
            Application.targetFrameRate = 60;
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

        // Check if the player is at max level
        public bool IsMaxLevel()
        {
            if(_currentLevel <= maxLevel)
            {
                return false;
            }
            else
            {
                Debug.Log("Player is Max level");
                return true;
            }
        }

        public void AddExperience(int amount)
        {
            if (!IsMaxLevel()) _experience += amount; // Add experience with chosen amount

            if(!IsMaxLevel() && _experience >= GetExperienceToNextLevel(_currentLevel))
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
            if(saveToLocalFile && saveToPrefabs) Debug.LogError("Select either Save To File or Save to prefab");
            else if(saveToLocalFile && !saveToPrefabs) SaveLocalData();
            else if(!saveToLocalFile && saveToPrefabs) SavePrefabData();
        }

        void SaveLocalData()
        {
            SaveSystem.SaveExperienceData(this);
            Debug.Log("Saved data local successful!");
        }

        void SavePrefabData()
        {
            PlayerPrefs.SetInt("CurrentLevel", _currentLevel);
            PlayerPrefs.SetInt("CurrentExperience", _experience);
            Debug.Log("Playerprefabs data is now saved!");
        }

        public void LoadData()
        {
            if (saveToLocalFile && saveToPrefabs) Debug.LogError("Select either Save To File or Save to prefab");
            else if (saveToLocalFile && !saveToPrefabs) LoadLocalData();
            else if (!saveToLocalFile && saveToPrefabs) LoadPrefabData();
        }

        void LoadLocalData() {

            ExperienceData experienceData = SaveSystem.LoadExperience();

            if (experienceData != null)
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

        void LoadPrefabData()
        {
            _currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            _experience = PlayerPrefs.GetInt("CurrentExperience");
            Debug.Log("Loadprefab data is now done!");
        }

        // Caution! This will delete all the stored local data in the game
        public void DeleteLocalFileData()
        {
            SaveSystem.DeleteExperienceData();
            Debug.Log("Local file data is now deleted");
        }
        // Caution! This will delete all the stored playerprefs data in the game
        public void DeletePrefsData() {
            PlayerPrefs.DeleteKey("CurrentLevel");
            PlayerPrefs.DeleteKey("CurrentExperience");
            Debug.Log("Playerprefs data has now been deleted!");
        }
    }
}


