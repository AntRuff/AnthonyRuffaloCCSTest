using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveLoad{
    //Path to the save folder
    public static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";

    //Initialize the class and creates the Save Folder if it doesn't exist
    public static void Init() {
        if (!Directory.Exists(SAVE_FOLDER)){
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    //Saves data to the level slot 
    public static void Save(string saveString, int level){
        File.WriteAllText(SAVE_FOLDER + "save_" + level + ".txt", saveString);
    }

    //Loads data from the level slot
    public static string Load(int level){
        if (File.Exists(SAVE_FOLDER + "save_" + level + ".txt")) {
            string saveString = File.ReadAllText(SAVE_FOLDER + "save_" + level + ".txt");
            return saveString;
        } else { return null; }
    }
}