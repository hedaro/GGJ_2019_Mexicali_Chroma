using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptorCanvasController : MonoBehaviour
{
    public string[] descriptionTextArray;
    public Text descriptionText;
    internal int sequence = 0;




    public void RefreshText()
    {
      
        if (sequence < descriptionTextArray.Length)
        {
            descriptionText.text = descriptionTextArray[sequence];
            sequence++;
        }
        else
        {
            gameObject.SetActive(false);
        }


    }




}
