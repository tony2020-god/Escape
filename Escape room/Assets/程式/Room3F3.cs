using UnityEngine;
using System;
using UnityEngine.UI;

public class Room3F3 : MonoBehaviour
{
    public GameObject cofferopen;
    public GameObject coffer;
    public GameObject door;


    public void Start()
    {
        if (GameManager.getRaysLight)
        {
            opencoffer();
        }
    }
    public void opencoffer()
    {
        cofferopen.SetActive(true);
    }
    public void cameracoffer()
    {
        coffer.SetActive(true);
    }
    public void cameraDoor()
    {
        door.SetActive(true);
    }
    public void retuenRoom()
    {
        coffer.SetActive(false);
        door.SetActive(false);
        string[] wordsText = { "第三個保險箱...還有一門..." };
        dialogue.instance.words = wordsText;
    }
    public void GetInput(string getInput)
    {
        string number = getInput;
        print("密" + getInput);
        if (number == "673442652")
        {
            opencoffer();
            string[] wordsText = { "取得紫外線燈和USB" };
            dialogue.instance.words = wordsText;
            dialogue.instance.Dia.SetActive(true);
            dialogue.instance.StartEffect();
            GameManager.getRaysLight = true;
            GameManager.instance.roomNumber.SetActive(true);
            GameManager.instance.RaysLight.SetActive(true);
            GameManager.instance.usb2.SetActive(true);
        }
    }
}

