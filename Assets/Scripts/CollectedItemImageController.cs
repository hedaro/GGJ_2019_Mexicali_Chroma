using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedItemImageController : MonoBehaviour
{

    internal string[] itemsPath = ["demo1", "demo2","demo3", "demo4", "demo5"];

    public void UpdateImageForItem(int index)
    {
        if (index < itemsPath.Length)
        {
            gameObject.GetComponent<Image>().sprite = Resources.Load(itemsPath[index]) as Sprite;
            gameObject.SetActive(true);

        }
    }

    public  void HideItemView()
    {
        gameObject.SetActive(false);
    }


}
