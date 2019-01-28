using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle = 0,
    Walking = 1
}

public enum Items
{
    Vinyl,
    Vendas,
    Tijeras,
    Alcohol,
    Pulsera,
    Baquetas,
    total
}

public class PlayerMovement : MonoBehaviour
{
    private Vector3 position;
    private Vector3 scale;
    private PlayerState playerState;
    private AudioManager SoundManager;


    public GameState gameState;
    public bool enter;
    public string otherName;
    public GameObject otherObject;
    public bool[] ItemObjects;
    public float playerSpeed;
    public ChangeRoom changeRoom;

    public bool greenUnlock;
    public bool yellowUnlock;
    public bool redUnlock;
    public bool blueUnlock;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager = GameObject.Find("SoundManager").GetComponent<AudioManager>();

        enter = false;
        SetPlayerState(PlayerState.Idle);

        ItemObjects = new bool[(int)Items.total];

        SoundManager.PlayMusic(TrackList.SON);
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

        if (Input.GetKeyDown("up") || Input.GetKeyDown("down"))
        {
            if(changeRoom != null)
            {
                transform.position = changeRoom.MoveCameraAndPlayer(transform.position);
            }
        }

            if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enter)
            { 
                ItemBehaviours(otherObject);
            }


            //gameState.itemsDescriptor.gameObject.SetActive(true);
            //gameState.itemsCollectedController.gameObject.SetActive(true);
        }
    }

    public void SetPlayerState(PlayerState state)
    {
        playerState = state;
        GetComponent<Animator>().SetInteger("state", (int)state);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("OnTriggerEnter2D");
        enter = true;
        otherObject = other.gameObject;
        //otherObject.GetComponent<SpriteOutline>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        print("OnTriggerExit2D");
        enter = false;
        otherObject = null;
    }

    private void greenColorUnlock()
    {
        greenUnlock = true;

        GameObject.Find("Tocadiscos").GetComponent<Animator>().SetBool("play", true);
        GameObject.Find("Pulsera").GetComponent<Animator>().SetBool("unlock", true);
        GameObject.Find("CuadroEsposa").GetComponent<Animator>().SetBool("unlock", true);
        SoundManager.PlayMusic(TrackList.DULCE_HABANA);

        GameObject.Find("SalaBackground").GetComponent<Animator>().SetBool("unlock", true);
        GameObject.Find("LavadoBackground").GetComponent<Animator>().SetBool("unlock", true);

        if (yellowUnlock && redUnlock && blueUnlock)
        {
            GameObject.Find("WCBackground").GetComponent<Animator>().SetBool("unlock", true);
        }
    }

    private void yellowColorUnlock()
    {
        yellowUnlock = true;
        GameObject.Find("AlcobaBackground").GetComponent<Animator>().SetBool("unlock", true);
        GameObject.Find("BibliotecaBackground").GetComponent<Animator>().SetBool("unlock", true);

        if (redUnlock)
        {
            GameObject.Find("MusicalBackground").GetComponent<Animator>().SetBool("unlock", true);
            GameObject.Find("Pasilo1Background").GetComponent<Animator>().SetBool("unlock", true);
        }

        if (greenUnlock && redUnlock && blueUnlock)
        {
            GameObject.Find("WCBackground").GetComponent<Animator>().SetBool("unlock", true);
        }
    }

    private void redColorUnlock()
    {
        redUnlock = true;

        //GameObject.Find("Alcohol").GetComponent<Animator>().SetBool("unlock", true);
        //GameObject.Find("Vendas").GetComponent<Animator>().SetBool("unlock", true);
        //GameObject.Find("Tijeras").GetComponent<Animator>().SetBool("unlock", true);

        GameObject.Find("Pasilo2Background").GetComponent<Animator>().SetBool("unlock", true);

        if (yellowUnlock)
        {
            GameObject.Find("MusicalBackground").GetComponent<Animator>().SetBool("unlock", true);
            GameObject.Find("Pasilo1Background").GetComponent<Animator>().SetBool("unlock", true);
        }

        if (greenUnlock && yellowUnlock && blueUnlock)
        {
            GameObject.Find("WCBackground").GetComponent<Animator>().SetBool("unlock", true);
        }
    }

    private void blueColorUnlock()
    {
        blueUnlock = true;

        //GameObject.Find("Bateria").GetComponent<Animator>().SetBool("unlock", true);
        GameObject.Find("ComedorBackground").GetComponent<Animator>().SetBool("unlock", true);

        if (greenUnlock && yellowUnlock && redUnlock)
        {
            GameObject.Find("WCBackground").GetComponent<Animator>().SetBool("unlock", true);
        }
    }

    private void ItemBehaviours(GameObject otherObject)
    {
        switch (otherObject.name)
        {
            /*
            case "Triangle":
                print("entro a : "+otherObject.name);
                Destroy(otherObject);
                break;
            */

            case "Vinyl":
                print("entro a : " + otherObject.name);
                otherObject.GetComponent<VinylAction>().activeAction();
                ItemObjects[(int)Items.Vinyl] = true;
                Destroy(otherObject);
                break;

            case "Tocadiscos":

                print("entro a : " + otherObject.name);

                if (ItemObjects[(int)Items.Vinyl])
                {
                    print("empezar la animacion y desabilitar box collider de tocadisco, para no volver a interactuar ");
                    otherObject.GetComponent<TocadiscosAction>().playVinyl();
                    greenColorUnlock();
                }
                else
                {
                    print("Mostrar mensaje de que falta el vinyl en el UI");
                    otherObject.GetComponent<TocadiscosAction>().activeAction();
                }
                break;

            case "Vendas":

                print("entro a : " + otherObject.name);
                otherObject.GetComponent<VendasAction>().activeAction();
                break;

            case "Tijeras":
                print("entro a : " + otherObject.name);
                if (redUnlock)
                {
                    ItemObjects[(int)Items.Tijeras] = true;
                    Destroy(otherObject);
                }
                else
                {
                    otherObject.GetComponent<TijerasAction>().activeAction();
                }
                break;

            case "Alcohol":

                print("entro a : " + otherObject.name);
                if (redUnlock)
                {
                    ItemObjects[(int)Items.Alcohol] = true;
                    Destroy(otherObject);
                }
                else
                {
                    otherObject.GetComponent<AlcoholAction>().activeAction();
                }

                break;

            case "Buro":
                print("entro a : " + otherObject.name);
                if (ItemObjects[(int)Items.Pulsera])
                {
                    yellowColorUnlock();
                }
                else
                {
                    otherObject.GetComponent<BuroAction>().activeAction();
                }

                break;

            case "Pulsera":

                print("entro a : " + otherObject.name);
                if (greenUnlock)
                {
                    ItemObjects[(int)Items.Pulsera] = true;
                    Destroy(otherObject);
                }
                else
                {
                    otherObject.GetComponent<PulseraAction>().activeAction();
                }

                break;

            case "Bateria":

                print("entro a : " + otherObject.name);
                if (blueUnlock)
                {
                    otherObject.GetComponent<BateriaAction>().playBateria();
                }
                else
                {
                    otherObject.GetComponent<BateriaAction>().activeAction();
                }

                break;

            case "Baquetas":

                print("entro a : " + otherObject.name);
                if (blueUnlock)
                {
                    ItemObjects[(int)Items.Baquetas] = true;
                    Destroy(otherObject);
                }
                else
                {
                    otherObject.GetComponent<BaquetasAction>().activeAction();
                }

                print("entro a : " + otherObject.name);
                otherObject.GetComponent<BaquetasAction>().activeAction();
                break;

            case "CuadroRevolucion":
                print("entro a : " + otherObject.name);
                otherObject.GetComponent<CuadroRevolucionAction>().activeAction();
                break;

            case "CuadroJazz":
                print("entro a : " + otherObject.name);
                otherObject.GetComponent<CuadroJazzAction>().activeAction();
                break;

        }
    }
}
