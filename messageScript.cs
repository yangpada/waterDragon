using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class messageScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text buttonText;
    public Text shopOwnerMessage;
    public Color32 messageOff;
    public Color32 messageOn;
    public GameObject[] shopUI;
    
    [HideInInspector]
    public int shopNum = 0;
    public string shopMessage;
    public GameObject inventoryObj;
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = messageOn;
        PlayerMove.canMove = false;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = messageOff;
        PlayerMove.canMove = true;
    }
 // Start is called before the first frame update
 
    void Start()
    {
        shopOwnerMessage.text = "hello " + SaveScript.pname + " how can i help you";
    }
 
    public void Message1()
    {
        shopOwnerMessage.text = shopMessage;
        if(inventoryObj != null)
        {
            if (shopMessage != "not much going on around here")
            {
                //inventoryObj.GetComponent<InventoryItems>().UpdateMessages(shopMessage);
            }
        }
    }
 
    public void Message2()
    {
        shopOwnerMessage.text = "select items from the list";
        shopUI[shopNum].SetActive(true);
        if (shopNum < 6)
        {
            shopUI[shopNum].GetComponent<BuyScript>().UpdateGold();
        }
    }
 
    void Update()
    {
        if (PlayerMove.canMove == true && PlayerMove.moving == true)
        {
            if (shopUI != null)
            {
                shopOwnerMessage.text = "hello " + SaveScript.pname + " how can i help you";
                shopUI[shopNum].SetActive(false);
            }
        }
    }
}