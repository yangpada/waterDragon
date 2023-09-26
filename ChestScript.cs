using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestScript : MonoBehaviour
{
    private Animator anim;
    public int goldAmt = 20;
    public GameObject particleEfffect;
    public GameObject spawnPoint;
    public GameObject canvasText;
    public Text goldAmtText;
    public float speed = 1.0f;
    public GameObject mainCam;
    private int goldDisplay;
    public GameObject inventoryObj;
    public AudioClip openChest;
    public bool crate = true;
 // Start is called before the first frame update
    
    void Start()
    {
        if (crate == false)
        {
            anim = GetComponent<Animator>();
        }
            canvasText.SetActive(true);
            goldDisplay = goldAmt;
    }
 
    private void Update()
    {
        if(canvasText.activeSelf == true)
        {
            //canvasText.transform.Translate(Vector3.up * speed * Time.deltaTime);
            goldAmtText.text = goldDisplay.ToString();
            //canvasText.transform.LookAt(mainCam.transform.position);
        }
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (crate == false)
        {
            if (other.CompareTag("Player"))
            {
                if (InventoryItems.key == true)
                {
                    anim.SetTrigger("open");
                    InventoryItems.gold += goldAmt;
                    goldAmt = 10;
                    inventoryObj.GetComponent<AudioSource>().clip = openChest;
                    inventoryObj.GetComponent<AudioSource>().Play();
                    Debug.Log("Gold  amt = " + InventoryItems.gold);
                }
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (crate == false)
        {
            if (other.CompareTag("Player"))
            {
                if (InventoryItems.key == true)
                {
                    anim.SetTrigger("close");
                    Time.timeScale = 1.0f;
                    //timescale >> 0.01f << very slow
                    //Destroy(gameObject); >> destroychest() void
                }
            }
        }
    }
 
    public void DestroyChest()
    {
        Destroy(gameObject);
    }
    public void Particles()
    {
        Instantiate(particleEfffect, spawnPoint.transform.position, spawnPoint.transform.rotation);
        canvasText.SetActive(true);
        if(crate == true)
        {
            InventoryItems.gold += goldAmt;
            goldAmt = 30;
            inventoryObj.GetComponent<AudioSource>().clip = openChest;
            inventoryObj.GetComponent<AudioSource>().Play();
        }
    }
}