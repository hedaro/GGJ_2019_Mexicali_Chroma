using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptorCanvasController : MonoBehaviour
{
    public string[] descriptionTextArray;
    public Text descriptionText;
    internal int sequence = 0;

    private bool isShow = false;
    public bool IsShown { get { return isShow; } }

    GameObject textBox;

    private void Start()
    {
        textBox = GameObject.Find("ItemDescriptorButton");
        textBox.SetActive(false);
        isShow = false;
    }

    public void hideTextBox()
    {
        textBox.SetActive(false);
        isShow = false;
    }

    public void showTextBox(string[] text)
    {
        descriptionTextArray = text;
        descriptionText.text = descriptionTextArray[0];
        sequence = 1;
        textBox.SetActive(true);
        isShow = true;

    }

    public void RefreshText()
    {
      
        if (sequence < descriptionTextArray.Length)
        {
            descriptionText.text = descriptionTextArray[sequence];
            sequence++;
        }
        else
        {
            hideTextBox();
            //gameObject.SetActive(false);
        }


    }




}
