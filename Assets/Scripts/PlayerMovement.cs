using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle = 0,
    Walking = 1
}

public class PlayerMovement : MonoBehaviour
{
    private Vector3 position;
    private Vector3 scale;
    private PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerState(PlayerState.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left") || Input.GetKey("right"))
        {
            position = transform.position;
            scale = transform.localScale;
            SetPlayerState(PlayerState.Walking);

            if (Input.GetKey("left"))
            {
                position.x -= 0.1f;
                transform.position = position;

                if (scale.x < 0)
                {
                    scale.x *= -1;
                    transform.localScale = scale;
                }
            }
            else if (Input.GetKey("right"))
            {
                position.x += 0.1f;
                transform.position = position;

                if (scale.x > 0)
                {
                    scale.x *= -1;
                    transform.localScale = scale;
                }
            }
        }
        else
        {
            SetPlayerState(PlayerState.Idle);
        }

        if (Input.GetKeyDown("space"))
        {

        }
    }

    public void SetPlayerState(PlayerState state)
    {
        playerState = state;
        GetComponent<Animator>().SetInteger("state", (int)state);
    }
}
