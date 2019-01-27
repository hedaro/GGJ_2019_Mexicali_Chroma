using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    public Vector2 cameraMovement;
    public Vector2 cameraDirection;
    public Vector2 playerDisplacement;
    public Room belongsToRoom;
    public Room leadsToRoom;
    public GameState gameState;

    // Estos dos se van a mover al script de room
    public Vector2 roomSize;
    public Vector2 roomPosition;

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
        if (other.CompareTag("Player") && belongsToRoom == GameState.currentRoom)
        {
            GameState.currentRoom = leadsToRoom;
            cameraPosition = Camera.main.transform.position;
            cameraPosition.x += cameraDirection.x * cameraMovement.x;
            cameraPosition.y += cameraDirection.y * cameraMovement.y;
            Camera.main.transform.position = cameraPosition;

            gameState.currentRoomPosition = roomPosition;
            gameState.currentRoomSize = roomSize;

            playerPosition = other.transform.position;
            playerPosition.x += playerDisplacement.x;
            playerPosition.y += playerDisplacement.y;
            other.transform.position = playerPosition;
        }
    }
}
