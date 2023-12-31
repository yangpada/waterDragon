using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public int number;
    public bool redMushroom = false;
    public bool purpleMushroom = false;
    public bool brownMushroom = false;
    public bool blueFlower = false;
    public bool redFlower = false;
    public bool key = false;
    public GameObject inventoryObject;
    public AudioSource audioPlayer;
    private void Start()
    {
        inventoryObject = GameObject.Find("InventoryCanvas");
        audioPlayer = inventoryObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //audioPlayer.clip = inventoryObject.GetComponent<InventoryItems>
        //().pickupSound;
        //audioPlayer.Play();
        if(other.CompareTag("Player"))
        {
            if (redMushroom == true)
            {
                if (InventoryItems.redMushrooms == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.redMushrooms++;
                Destroy(gameObject);
            }
            else if (blueFlower == true)
            {
                if (InventoryItems.blueFlowers == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.blueFlowers++;
                Destroy(gameObject);
            }
            else if (purpleMushroom == true)
            {
                if (InventoryItems.purpleMushrooms == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.purpleMushrooms++;
                Destroy(gameObject);
            }
            else if (brownMushroom == true)
            {
                if (InventoryItems.brownMushrooms == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.brownMushrooms++;
                Destroy(gameObject);
            }
            else if (redFlower == true)
            {
                if(InventoryItems.redFlowers == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.redFlowers++;
                Destroy(gameObject);
            }
            else if (key == true)
            {
                DisplayIcons();
                InventoryItems.key = true;
                Destroy(gameObject);
            }
            else
            {
                DisplayIcons();
                Destroy(gameObject);
            }
        }
    }
    void DisplayIcons()
    {
        InventoryItems.newIcon = number;
        InventoryItems.iconUpdate = true;
    }
}