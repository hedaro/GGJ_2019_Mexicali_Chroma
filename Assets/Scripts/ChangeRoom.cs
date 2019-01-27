using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    public Vector2 cameraDirection;
    public Vector2 playerDisplacement;
    public RoomParameters belongsToRoom;
    public RoomParameters leadsToRoom;

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
            GameState.currentRoom = leadsToRoom.roomType;
            cameraPosition = Camera.main.transform.position;
            cameraPosition.x += cameraDirection.x * Camera.main.GetComponent<CameraMovement>().cameraSize.x;
            cameraPosition.y += cameraDirection.y * Camera.main.GetComponent<CameraMovement>().cameraSize.y;
            Camera.main.transform.position = cameraPosition;

            GameState.currentRoomPosition = leadsToRoom.gameObject.transform.position;
            GameState.currentRoomSize = leadsToRoom.Size;

            playerPosition = other.transform.position;
            playerPosition.x += playerDisplacement.x;
            playerPosition.y += playerDisplacement.y;
            other.transform.position = playerPosition;
        }
    }
}
