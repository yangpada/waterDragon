using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveScript : MonoBehaviour
{
    public static int instance = 0;
    public static int pchar = 0;
    public static string pname = "player";
    public static GameObject spawnPoint;
    public static GameObject theTarget;
    public static float manaAmt = 1.0f;
    public static float staminaAmt = 1.0f;
    public static bool invisible = false;
    public static bool invulnerable = false;
    public static float strengthAmt = 0.1f;
    public static float manaPowerAmt = 0.1f;
    public static float staminaPowerAmt = 0.1f;
    public static int killAmt = 0;
    public static int weaponChoice = 0;
    public static bool weaponChange = false;
    public static bool carryingWeapon = false;
    public static int armor = 0;
    public static bool changeArmor = false;
    private int checkAmt = 10;
    public static float playerLevel = 0.1f;
    public static int weaponIncrease;
    public static float playerHealth = 1.0f;
    public static int strengthIncrease = 0;
    public static float armorValue = 0;
    public static int enemiesOnScreen;
    public static bool newGame = false;

    public static bool saving = false;
    public static bool continueData = false;
    private bool checkForLoad = false;
    private GameObject inventoryObj;

    //public save data

    public int pcharS;
    public string pnameS;
    public float strengthAmtS;
    public float manaPowerAmtS;
    public float staminaPowerAmtS;
    public int killAmtS;
    public int weaponChoiceS;
    public bool carryingWeaponS;
    public int armorS;
    public float playerLevelS;
    public int weaponIncreaseS;
    public float playerHealthS;
    public int strengthIncreaseS;
    public float armorValueS;
    public int goldS;
    public bool keyS;
    public int redMushroomsS;
    public int purpleMushroomsS;
    public int brownMushroomsS;
    public int blueFlowersS;
    public int redFlowersS;
    public int rootsS;
    public int leafDewS;
    public int dragonEggS;
    public int redPotionS;
    public int bluePotionS;
    public int greenPotionS;
    public int purplePotionS;
    public int breadS;
    public int cheeseS;
    public int meatS;
    public bool magicCollectedS;
    public bool spellsCollectedS;
    public bool[] weaponS;
    public int[] objectTypeS;

    private void Awake()
    {
        instance++;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (instance > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
        if (newGame == true)
        {
            pname = "player";
            manaAmt = 1.0f;
            staminaAmt = 1.0f;
            strengthAmt = 0.1f;
            manaPowerAmt = 0.1f;
            staminaPowerAmt = 0.1f;
            invisible = false;
            invulnerable = false;
            killAmt = 0;
            weaponChoice = 0;
            weaponChange = false;
            carryingWeapon = false;
            armor = 0;
            changeArmor = false;
            playerLevel = 0.1f;
            weaponIncrease = 0;
            playerHealth = 1.0f;
            strengthIncrease = 0;
            armorValue = 0;
            enemiesOnScreen = 0;
            //BookCollect.magicCollected = false;
            //BookCollect.spellsCollected = false;
            newGame = false;
        }
        if(continueData == true)
        {
            string fileLocation = Application.persistentDataPath + "/save.dat";
            StreamReader reader = new StreamReader(fileLocation);
            string saveData = reader.ReadToEnd();
            reader.Close();
            JsonUtility.FromJsonOverwrite(saveData, this);
            pchar = pcharS;
            continueData = false;
            checkForLoad = true;
        }
    }
    // Update is called once per frame
    /*void Update()
    {
        if (manaAmt < 1.0)
        {
        manaAmt += (manaPowerAmt / 10 + 0.04f) * Time.deltaTime;
        }
        if (manaAmt <= 0)
        {
        manaAmt = 0;
        }
        if (manaAmt < 0.03)
        {
            invisible = false;
            invulnerable = false;
            strengthIncrease = 0;
        }
        if (staminaAmt < 1.0)
        {
            staminaAmt += (staminaPowerAmt / 10 + 0.04f) * Time.deltaTime;
        }
        if (staminaAmt <= 0)
        {
            staminaAmt = 0;
        }
        if (killAmt == checkAmt)
        {
            playerLevel += 0.1f;
            checkAmt = killAmt + 10;
            strengthAmt = playerLevel;
            manaPowerAmt = playerLevel;
            staminaPowerAmt = playerLevel;
            weaponIncrease = System.Convert.ToInt32(strengthAmt * 90);
        }
        if (armor == 1)
        {
            armorValue = 0.002f;
        }
        if (armor == 2)
        {
            armorValue = 0.004f;
        }
        if(saving == true)
        {
            saving = false;
            if(inventoryObj == null)
            {
            inventoryObj = GameObject.Find("InventoryCanvas");
            }
             pcharS = pchar;
             pnameS = pname;
            strengthAmtS = strengthAmt;
            manaPowerAmtS = manaPowerAmt;
            staminaPowerAmtS = staminaPowerAmt;
            killAmtS = killAmt;
            weaponChoiceS = weaponChoice;
            carryingWeaponS = carryingWeapon;
            armorS = armor;
            playerLevelS = playerLevel;
            weaponIncreaseS = weaponIncrease;
            playerHealthS = playerHealth;
            strengthIncreaseS = strengthIncrease;
            armorValueS = armorValue;
            goldS = InventoryItems.gold;
            keyS = InventoryItems.key;
            redMushroomsS = InventoryItems.redMushrooms;
            purpleMushroomsS = InventoryItems.purpleMushrooms;
            brownMushroomsS = InventoryItems.brownMushrooms;
            blueFlowersS = InventoryItems.blueFlowers;
            redFlowersS = InventoryItems.redFlowers;
            rootsS = InventoryItems.roots;
            leafDewS = InventoryItems.leafDew;
            dragonEggS = InventoryItems.dragonEgg;
            redPotionS = InventoryItems.redPotion;
            bluePotionS = InventoryItems.bluePotion;
            greenPotionS = InventoryItems.greenPotion;
            purplePotionS = InventoryItems.purplePotion;
            breadS = InventoryItems.bread;
            cheeseS = InventoryItems.cheese;
            meatS = InventoryItems.meat;
            magicCollectedS = BookCollect.magicCollected;
            spellsCollectedS = BookCollect.spellsCollected;
            weaponS = inventoryObj.GetComponent<InventoryItems>().weapons;
            for(int i = 0; i < 16; i++)
            {
                objectTypeS[i] = inventoryObj.GetComponent<InventoryItems>
                  ().emptySlots
                  [i].transform.gameObject.GetComponent<HintMessage>
                  ().objectType;
            }
            string saveData = JsonUtility.ToJson(this);
            string fileLocation = Application.persistentDataPath + "/save.dat";
            StreamWriter writer = new StreamWriter(fileLocation);
            writer.WriteLine(saveData);
            writer.Close();
        }

        if(checkForLoad == true)
        {
            int sceneNumber = SceneManager.GetActiveScene().buildIndex;
            if(sceneNumber == 2)
            {
                if(inventoryObj == null)
                {
                   inventoryObj = GameObject.Find("InventoryCanvas");
                }
                if(inventoryObj != null)
                {
                    PlayerMove.canMove = true;
                    pname = pnameS;
                    strengthAmt = strengthAmtS;
                    manaPowerAmt = manaPowerAmtS;
                    staminaPowerAmt = staminaPowerAmtS;
                    killAmt = killAmtS;
                    weaponChoice = weaponChoiceS;
                    carryingWeapon = carryingWeaponS;
                    armor = armorS;
                    playerLevel = playerLevelS;
                    weaponIncrease = weaponIncreaseS;
                    playerHealth = playerHealthS;
                    strengthIncrease = strengthIncreaseS;
                    armorValue = armorValueS;
                    InventoryItems.gold = goldS;
                    InventoryItems.key = keyS;
                    InventoryItems.redMushrooms = redMushroomsS;
                    InventoryItems.purpleMushrooms = purpleMushroomsS;
                    InventoryItems.brownMushrooms = brownMushroomsS;
                    InventoryItems.blueFlowers = blueFlowersS;
                    InventoryItems.redFlowers = redFlowersS;
                    InventoryItems.roots = rootsS;
                    InventoryItems.leafDew = leafDewS;
                    InventoryItems.dragonEgg = dragonEggS;
                    InventoryItems.redPotion = redPotionS;
                    InventoryItems.bluePotion = bluePotionS;
                    InventoryItems.greenPotion = greenPotionS;
                    InventoryItems.purplePotion = purplePotionS;
                    InventoryItems.bread = breadS;
                    InventoryItems.cheese = cheeseS;
                    InventoryItems.meat = meatS;
                    BookCollect.magicCollected = magicCollectedS;
                    BookCollect.spellsCollected = spellsCollectedS;
                    if(magicCollectedS == true)
                    {
                        inventoryObj.GetComponent<InventoryItems>
                    ().magicUI.SetActive(true);
                    }
                    if (spellsCollectedS == true)
                    {
                        inventoryObj.GetComponent<InventoryItems>
                    ().spellsUI.SetActive(true);
                    }
                        inventoryObj.GetComponent<InventoryItems>().weapons = weaponS;
                    if(carryingWeapon == true)
                    {
                        weaponChange = true;
                    }
                    if(armor > 0)
                    {
                        changeArmor = true;
                    }
                    for (int i = 0; i < 16; i++)
                    {
                        inventoryObj.GetComponent<InventoryItems>().emptySlots
                    [i].sprite = inventoryObj.GetComponent<InventoryItems>
                    ().icons[objectTypeS[i]];
                        inventoryObj.GetComponent<InventoryItems>().emptySlots
                    [i].transform.gameObject.GetComponent<HintMessage>
                    ().objectType = objectTypeS[i];
                    }
                    checkForLoad = false;
                }
            }
        }
    }*/
}