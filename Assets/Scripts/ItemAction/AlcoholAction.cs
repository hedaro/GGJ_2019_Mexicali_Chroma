using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activeAction()
    {
        ItemDescriptorCanvasController messageBox = GameObject.Find("ItemDescriptionCanvas").GetComponent<ItemDescriptorCanvasController>();
        PlayerMovement player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        //if (!player.greenUnlock)
        {
            messageBox.showTextBox(new string[1] { "Una botella de Alcohol, tal vez deba curar a Mandolina" });
        }
        //print("activeAction AlcoholAction");
    }
}
