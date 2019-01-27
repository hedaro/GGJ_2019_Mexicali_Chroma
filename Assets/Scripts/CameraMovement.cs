using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
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

        Vector2 minValue = GameState.currentRoomPosition - GameState.currentRoomSize/2 + cameraSize/2;
        Vector2 maxValue = GameState.currentRoomPosition + GameState.currentRoomSize/2 - cameraSize/2;
        if (cameraPosition.x != targetPosition.x)
        {
            cameraPosition.x = Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x);
            transform.position = cameraPosition;
        }
    }
}
