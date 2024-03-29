using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

[System.Serializable]
public class GameData
{
    public bool isFinished;
    //Jumpkingscript's data
    public float totalTimePlayed;
    public Vector3 playerPosition;
    public Dictionary<string, bool> itemsCollected;

    //GameObjectsController data
    public string currentPosition;

    //raven's data
    public Vector3 ravenPosition;
    public bool isMoving;
    public int targetIndex ;

    //SaveSlot ID
    public int ID { get; set; }

    // the values defined in this constructor will be default values
    // the game starts with when there's no data to load
    public GameData()
    {
        isFinished = false;
        totalTimePlayed = 0;
        playerPosition = new Vector3(224.5f, 4.5f, -1.8f);
        // playerPosition = new Vector3(218.0f, 1025.5f, -1.8f);
    }
    public bool CheckIfFinished()
    {
        return isFinished;
    }

    public float GetTimePlayed()
    {
        return totalTimePlayed;
    }
}
