using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedItemImageController : MonoBehaviour
{

    internal string[] itemsPath = new string[]{ "vinyl", "demo2", "demo3", "demo4", "demo5"} ;

    public void UpdateImageForItem(int index)
    {
        if (index < itemsPath.Length)
        {
            Debug.Log(itemsPath[index]);
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(itemsPath[index]);
            gameObject.SetActive(true);

        }
    }

    public  void HideItemView()
    {
        gameObject.SetActive(false);
    }


    private void Awake()
    {

    }


}
