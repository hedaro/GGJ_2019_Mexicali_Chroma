using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    public GameState gameState;
    private Vector2 targetPosition;
    private Vector3 cameraPosition;
    public Vector2 cameraSize;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = target.transform.position;
        cameraPosition = transform.position;

        Vector3 minValue = gameState.currentRoomPosition - gameState.currentRoomSize / 2 + cameraSize / 2;
        Vector3 maxValue = gameState.currentRoomPosition + gameState.currentRoomSize / 2 - cameraSize / 2;
        if (cameraPosition.x != targetPosition.x)
        {
            cameraPosition.x = Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x);
            transform.position = cameraPosition;
        }
    }
}
