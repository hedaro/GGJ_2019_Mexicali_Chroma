using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChangeRoomType
{
    Door,
    StairsUp,
    StairsDown
}

public class ChangeRoom : MonoBehaviour
{
    public Vector2 cameraDirection;
    public Vector2 playerDisplacement;
    public RoomParameters belongsToRoom;
    public RoomParameters leadsToRoom;
    public ChangeRoomType type;

    private Vector3 cameraPosition;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && belongsToRoom.roomType == GameState.currentRoom)
        {
            if (type == ChangeRoomType.Door)
            {
                other.transform.position = MoveCameraAndPlayer(other.transform.position);
            }
            else if (type == ChangeRoomType.StairsUp || type == ChangeRoomType.StairsDown)
            {
                other.GetComponent<PlayerMovement>().changeRoom = this;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && type == ChangeRoomType.StairsUp ||type == ChangeRoomType.StairsDown)
        {
            other.GetComponent<PlayerMovement>().changeRoom = null;
        }
    }

    public Vector3 MoveCameraAndPlayer(Vector3 playerPosition)
    {
        GameState.currentRoom = leadsToRoom.roomType;
        cameraPosition = Camera.main.transform.position;
        cameraPosition.x += cameraDirection.x * Camera.main.GetComponent<CameraMovement>().cameraSize.x;
        cameraPosition.y += cameraDirection.y * Camera.main.GetComponent<CameraMovement>().cameraSize.y;
        Camera.main.transform.position = cameraPosition;

        GameState.currentRoomPosition = leadsToRoom.gameObject.transform.position;
        GameState.currentRoomSize = leadsToRoom.Size;
    
        playerPosition.x += playerDisplacement.x;
        playerPosition.y += playerDisplacement.y;
        return playerPosition;
    }
}
