using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HintMessage : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler, IPointerClickHandler
    {
        public GameObject hintBox;
        public Text message;
        private bool displaying = true;
        private bool overIcon = false;
        public int objectType = 0;
        private Vector3 screenPoint;
        public GameObject theCanvas;
        public Sprite CursorBasic;
        public Sprite CursorHand;
        public Image CursorImage;
        public AudioSource audioPlayer;
        public GameObject inventoryObject;
        public bool magic = false;
        public bool spells = false;
        public bool left = true;

        public void OnPointerEnter(PointerEventData eventData)
        {
            overIcon = true;
            if (displaying == true)
            {
                //CursorImage.sprite = CursorHand;
                hintBox.SetActive(true);
                if (left == true)
                {
                    screenPoint.x = Input.mousePosition.x + 600;
                }
                if(left == false)
                {
                    screenPoint.x = Input.mousePosition.x - 600;
                }
                screenPoint.y = Input.mousePosition.y;
                screenPoint.z = 1f;
                hintBox.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
                MessageDisplay();
            }
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            //CursorImage.sprite = CursorBasic;
            overIcon = false;
            hintBox.SetActive(false);
        }

        // Start is called before the first frame update
        void Start()
        {
            hintBox.SetActive(false);
            audioPlayer = inventoryObject.GetComponent<AudioSource>();
        }
        // Update is called once per frame
        void Update()
        {
            if(overIcon == true)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    audioPlayer.clip = inventoryObject.GetComponent<InventoryItems>().selectSound;
                    audioPlayer.Play();
                    displaying = false;
                    hintBox.SetActive(false);
                if(magic == true)
                {
                    if (objectType != 0)
                    {
                        inventoryObject.GetComponent<InventoryItems>().selected = objectType - 20;
                        inventoryObject.GetComponent<InventoryItems>().set = true;
                    }
                }
                if (spells == true)
                {
                    if (objectType != 0)
                    {
                        inventoryObject.GetComponent<InventoryItems>().selected = objectType - 30;
                        inventoryObject.GetComponent<InventoryItems>().setTwo = true;
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            displaying = true;
        }
    }
    void MessageDisplay()
    {
        if (objectType == 0)
        {
            message.text = "empty";
        }
        if(objectType == 1)
        {
            message.text = InventoryItems.redMushrooms.ToString() + " redmushrooms";
        }
         if (objectType == 2)
        {
            message.text = InventoryItems.purpleMushrooms.ToString() + " purple mushrooms to be used in potions";
        }
        if (objectType == 3)
        {
            message.text = InventoryItems.brownMushrooms.ToString() + " brownmushrooms to be used in potions";
        }
        if (objectType == 4)
        {
            message.text = InventoryItems.blueFlowers.ToString() + " blueflowers to be used in potions";
        }
        if (objectType == 5)
        {
            message.text = InventoryItems.redFlowers.ToString() + " redflowers";
        }
        if (objectType == 6)
        {
            message.text = InventoryItems.roots.ToString() + " roots to beused in potions";
        }
        if (objectType == 7)
        {
            message.text = InventoryItems.leafDew.ToString() + " leaf dew to be used in potions";
        }
        if (objectType == 8)
        {
            message.text = "key to open chests";
        }
        if (objectType == 9)
        {
            message.text = InventoryItems.dragonEgg.ToString() + " dragon eggs to be used in potions";
        }
        if (objectType == 10)
        {
            message.text = InventoryItems.bluePotion.ToString() + " bluepotion to be used in potions";
        }
        if (objectType == 11)
        {
            message.text = InventoryItems.purplePotion.ToString() + " purplepotion to be used in potions";
        }
        if (objectType == 12)
        {
            message.text = InventoryItems.greenPotion.ToString() + " greenpotion to be used in potions";
        }
        if (objectType == 13)
        {
            message.text = InventoryItems.redPotion.ToString() + " red potion to be used in potions";
        }
        if (objectType == 14)
        {
            message.text = InventoryItems.bread.ToString() + " bread used to replenish health";
        }
        if (objectType == 15)
        {
            message.text = InventoryItems.cheese.ToString() + " cheese used to replenish health";
        }
        if (objectType == 16)
        {
            message.text = InventoryItems.meat.ToString() + " meat used to replenish health";
        }
        if (objectType == 20)
        {
            message.text = "explosive fire attack";
        }
        if (objectType == 21)
        {
            message.text = "replenishes full health";
        }
        if (objectType == 22)
        {
            message.text = "become invisible for as long as mana lasts";
        }
        if (objectType == 23)
        {
            message.text = "become invulnerable for as long as mana lasts";
        }
        if (objectType == 24)
        {
            message.text = "double strength for as long as mana lasts";
        }
        if (objectType == 25)
        {
            message.text = "swirl attack";
        }
        if (objectType == 30)
        {
            message.text = "magic attack 1";
        }
        if (objectType == 31)
        { 
            message.text = "magic attack 2";
        }
        if (objectType == 32)
        {   
            message.text = "magic attack 3";
        }
        if (objectType == 33)
        {
            message.text = "magic attack 4";
        }
        if (objectType == 34)
        {
            message.text = "magic attack 5";
        }
        if (objectType == 35)
        {
            message.text = "magic attack 6";
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        theCanvas.GetComponent<CreatePotion>().thisValue = objectType;
        theCanvas.GetComponent<CreatePotion>().UpdateValues();
    }
}