using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// This script is creating a filestream and serializes the data that you wants to be saved.
// It creates a instance ExperienceData class that contains data from ExperienceManager.

public static class SaveSystem
{
    public static void SaveExperienceData(ExperienceManager experienceManager)
    {
        BinaryFormatter formatter = new BinaryFormatter(); // Create new instance of binaryformatter to serialize the data
        string path = Application.persistentDataPath + "/experience.data"; // Give the serialized file a name and select path.
        FileStream stream = new FileStream(path, FileMode.Create); // Create a file stream to save the file

        ExperienceData data = new ExperienceData(experienceManager); // Create new instance of ExperienceData with contains the data from experiencemanager class

        formatter.Serialize(stream, data); // Serialize the data 
        stream.Close(); // Close stream (always needed to close after opening a stream)
    }

    public static ExperienceData LoadExperience()
    {
        string path = Application.persistentDataPath + "/experience.data"; // Set path to the save folder

        if (File.Exists(path)) // if the file already exist load the file.
        {
            BinaryFormatter formatter = new BinaryFormatter(); // Create new instance of binaryformatter to deserialize the data
            FileStream stream = new FileStream(path, FileMode.Open); // Create a file stream to open the file

            ExperienceData data = formatter.Deserialize(stream) as ExperienceData; // Deserialize the data from the file
            stream.Close(); // Close the file stream

            return data;
        }
        else
        {
            Debug.Log("Not Finding File");
            return null;
        }
    }

    public static void DeleteExperienceData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "experience.data");

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("File deleted: " + "experience.data");
        }
        else
        {
            Debug.Log("File not found: " + "experience.data");
        }
    }
}



