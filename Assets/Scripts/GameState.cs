using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Room
{
    Center,
    Left,
    Right
}

public class GameState : MonoBehaviour
{
    public static Room currentRoom;
    // Start is called before the first frame update
    void Start()
    {
        currentRoom = Room.Center; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
