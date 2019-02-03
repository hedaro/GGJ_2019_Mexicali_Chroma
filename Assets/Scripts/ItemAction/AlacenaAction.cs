using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlacenaAction : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("Alacena").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activeAction()
    {
        PlayerMovement player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        if (animator.GetBool("open"))
        {
            animator.SetBool("open", false);
            if (!player.ItemObjects[(int)Items.Vendas])
            {
                GameObject.Find("Vendas").GetComponent<SpriteRenderer>().enabled=false;
            }
        }
        else
        {
            animator.SetBool("open", true);
            if (!player.ItemObjects[(int)Items.Vendas])
            {
                GameObject.Find("Vendas").GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        //ItemDescriptorCanvasController messageBox = GameObject.Find("ItemDescriptionCanvas").GetComponent<ItemDescriptorCanvasController>();
        //messageBox.showTextBox(new string[1] { "50 Sones Radio Vieja. Cachao Cógele el Golpe" });
        //print("activeAction VinylAction");
    }
}
