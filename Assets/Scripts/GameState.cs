using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static Room currentRoom;
    public static Vector2 currentRoomSize;
    public static Vector2 currentRoomPosition;
    public ItemDescriptorCanvasController itemDescriptor;
    // Start is called before the first frame update
    void Start()
    {
        currentRoom = Room.Sala;
        currentRoomSize = new Vector2(179.2f, 67.2f);
        currentRoomPosition = new Vector2(448.0f, 0.0f);
        itemDescriptor.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
