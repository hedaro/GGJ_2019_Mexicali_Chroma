using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocadiscosAction : MonoBehaviour
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
    	print("activeAction TocadiscosAction");
    }

    public void playVinyl()
    {
        GetComponent<Animator>().SetBool("play", true);
        GetComponent<BoxCollider2D>().enabled = false;
        print("playVinyl Function");
    }
}
