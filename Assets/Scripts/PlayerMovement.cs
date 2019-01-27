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
    
    public bool enter;
    public string otherName;
    public GameObject otherObject;
    public bool isDestroyed;
    public float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        enter = false;
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
                position.x -= playerSpeed;
                transform.position = position;

                if (scale.x < 0)
                {
                    scale.x *= -1;
                    transform.localScale = scale;
                }
            }
            else if (Input.GetKey("right"))
            {
                position.x += playerSpeed;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enter)
            {
                switch (otherObject.name) 
                {
                    case "Triangle":
                        print("entro a : "+otherObject.name);
                        Destroy(otherObject);
                        isDestroyed = true;
                        break;

                    case "Hexagon":
                        print("entro a : "+otherObject.name);
                        otherObject.GetComponent<ItemAction>().activeAction();
                        break;

                }

            }
        }
    }

    public void SetPlayerState(PlayerState state)
    {
        playerState = state;
        GetComponent<Animator>().SetInteger("state", (int)state);
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //   print("OnTriggerEnter2D");
    //   enter = true;
    //   otherObject = other.gameObject;
    //   otherObject.GetComponent<Animator>().SetBool("overlap",true);
    //}

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    print("OnTriggerExit2D");
    //    enter = false;

    //    if (!isDestroyed)
    //    {
    //        otherObject.GetComponent<Animator>().SetBool("overlap",false);
    //    }
    //    else 
    //    {
    //        isDestroyed = false;
    //    }
        
    //    otherObject = null;
    //}
}
