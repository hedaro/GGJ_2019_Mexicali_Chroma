using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendasAction : MonoBehaviour
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
        if (GameObject.Find("Vendas").GetComponent<SpriteRenderer>().enabled)
        {
            ItemDescriptorCanvasController messageBox = GameObject.Find("ItemDescriptionCanvas").GetComponent<ItemDescriptorCanvasController>();
            messageBox.showTextBox(new string[1] { "¿Vendas?" });
        }
        //print("activeAction VendasAction");
    }
}
