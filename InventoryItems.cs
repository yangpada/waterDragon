using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryItems : MonoBehaviour 
{
    public GameObject inventoryMenu;
    public GameObject openBook;
    public GameObject closedBook;
    public GameObject potionBook;

    public GameObject messageBox;
    private AudioSource audioPlayer;
    public AudioClip bookOpenSound;

    public AudioClip selectSound;
    public AudioClip buySound;
    public AudioClip createPotionSound;
    public AudioClip pickupSound;
 
    public Image[] emptySlots;
    public Sprite[] icons;
        
    public Sprite emptyIcon;
    public static int redMushrooms = 0;
    public static int purpleMushrooms = 0;
    public static int brownMushrooms = 0;
    public static int blueFlowers = 0;
    public static int redFlowers = 0;
    public static int roots = 0;
    public static int leafDew = 0;
    public static int dragonEgg = 0;
    public static int redPotion = 0;
    public static int bluePotion = 0;
    public static int greenPotion = 0;
    public static int purplePotion = 0;
    public static int bread = 0;
    public static int cheese = 0;
    public static int meat = 0;
    public static bool key = true;
    public static int newIcon = 0;
    public static int gold = 0;
    public static bool iconUpdate = false;
    private int max;
    public GameObject theCanvas;
    [HideInInspector]
    public string entry;
    public string[] items;
    [HideInInspector]
    public int currentID = 0;
    [HideInInspector]
    public int checkAmt = 0;
    private int maxTwo;
    private int maxThree;
    public Image[] UISlots;
    public Sprite[] magicIcons;
    public Sprite[] spellIcons;
    public KeyCode[] keys;
    public bool set = false;
    public bool setTwo = false;
    [HideInInspector]
    public int selected = 0;
    public int[] magicAttack;
    public GameObject magicParticle;

    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        potionBook.SetActive(true);
        max = emptySlots.Length;
        maxTwo = items.Length;
        maxThree = emptySlots.Length;
        audioPlayer = GetComponent<AudioSource>();

        //Temp
        redMushrooms = 0;
        purpleMushrooms = 0;
        brownMushrooms = 0;
        blueFlowers = 0;
        redFlowers = 0;
        roots = 0;
        leafDew = 0;
        bluePotion = 0;
        greenPotion = 0;
        purplePotion = 0;
        redPotion = 0;
        bread = 0;
        cheese = 0;
        meat = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(iconUpdate == true)
        {
            for(int i = 0; i < max; i++)
            {
                if(emptySlots[i].sprite == emptyIcon)
                {
                    max = i;
                    emptySlots[i].sprite = icons[newIcon];

                    emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = newIcon;

                }
            }
            StartCoroutine(Reset());
        }

        if(set == true)
        {
            for(int i = 0; i < UISlots.Length; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    set = false;
                    UISlots[i].sprite = magicIcons[selected];
                    magicAttack[i] = selected;
                    theCanvas.GetComponent<CreatePotion>().Removed(selected);
                }
            }
        }
        if (setTwo == true)
        {
            for (int i = 0; i < UISlots.Length; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    setTwo = false;
                    UISlots[i].sprite = spellIcons[selected];
                    magicAttack[i] = selected += 6;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(magicParticle, SaveScript.spawnPoint.transform.position, SaveScript.spawnPoint.transform.rotation);
        }
    }
    public void CheckStatics()
    {
        for(int i = 0; i < maxTwo; i++)
        {
            if(i == currentID)
            {
                maxTwo = i;
                entry = items[i];
                checkAmt = System.Convert.ToInt32(typeof(InventoryItems).GetField(entry).GetValue(null));
                checkAmt--;
                typeof(InventoryItems).GetField(entry).SetValue(null, checkAmt);
                if(checkAmt == 0)
                {
                    RemoveIcon(i);
                }
            }
        }
        maxTwo = items.Length;
    }
    public void RemoveIcon(int iconType)
    {
        for(int i = 0; i < maxThree; i++)
        {
            if(emptySlots[i].sprite == icons[iconType])
            {
                maxThree = i;
                emptySlots[i].sprite = icons[0];
                emptySlots[i].transform.gameObject.GetComponent<HintMessage>
                ().objectType = 0;
            }
        }
        maxThree = emptySlots.Length;
    }
    public void OpenMenu()
    {
        messageBox.SetActive(false);
        inventoryMenu.SetActive(true);
        openBook.SetActive(true);
        closedBook.SetActive(false);
        audioPlayer.clip = bookOpenSound;
        audioPlayer.Play();
        Time.timeScale = 0;
    }
    public void CloseMenu()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        Time.timeScale = 1;
    }
    public void OpenPotionBook()
    {
        potionBook.SetActive(true);
    }
    public void ClosePotionBook()
    {
        theCanvas.GetComponent<CreatePotion>().value = 0;
        theCanvas.GetComponent<CreatePotion>().thisValue = 0;
        potionBook.SetActive(false);
    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.1f);
        iconUpdate = false;
        max = emptySlots.Length;
    }
}