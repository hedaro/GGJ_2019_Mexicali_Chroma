using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinylAction : MonoBehaviour
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
        messageBox.showTextBox(new string[1] { "50 Sones Radio Vieja. Cachao Cógele el Golpe" });
        //print("activeAction VinylAction");
    }
}
