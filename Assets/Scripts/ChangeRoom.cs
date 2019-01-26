using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    public Vector2 cameraMovement;
    public Vector2 cameraDirection;
    public Room belongsToRoom;
    public Room leadsToRoom;
    private Vector3 cameraPosition;

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
        print("Collided");
        if (other.CompareTag("Player") && belongsToRoom == GameState.currentRoom)
        {
            GameState.currentRoom = leadsToRoom;
            cameraPosition = Camera.main.transform.position;
            cameraPosition.x += cameraDirection.x * cameraMovement.x;
            cameraPosition.y += cameraDirection.y * cameraMovement.y;
            Camera.main.transform.position = cameraPosition;
        }
    }
}
