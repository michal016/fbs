using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    // Save game to file
    public static void Save() {
        GameState gs = new GameState();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, GameState.levelStars);
        file.Close();
    }

    // Load Game from file
    public static void Load() {
        if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            int[] newGameState = (int[])bf.Deserialize(file);
            GameState.levelStars = newGameState;
            file.Close();
        }
    }
}