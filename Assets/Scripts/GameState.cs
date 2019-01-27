using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Room
{
    Center,
    Left,
    Right,
    UpperLeft
}

public class GameState : MonoBehaviour
{
    public static Room currentRoom;
    public Vector2 currentRoomSize;
    public Vector2 currentRoomPosition;
    // Start is called before the first frame update
    void Start()
    {
        currentRoom = Room.Center;
        currentRoomSize = new Vector2(12.8f, 7.2f);
        currentRoomPosition = new Vector2(0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
