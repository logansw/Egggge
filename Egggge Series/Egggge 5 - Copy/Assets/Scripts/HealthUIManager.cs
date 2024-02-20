using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUIManager : MonoBehaviour
{
    [SerializeField] Player playerOne;
    [SerializeField] Player playerTwo;

    public GameObject eggHP;
    public int oneHP;
    public int twoHP;

    public GameObject[] healthBarOne;
    public GameObject[] healthBarTwo;

    // Start is called before the first frame update
    void Start()
    {
        float step = 0.5f;  // How far apart each egg sprite is

        playerOne = GameObject.Find("PlayerOne").GetComponent<Player>();    // Grabs correct references to each player
        playerTwo = GameObject.Find("PlayerTwo").GetComponent<Player>();

        oneHP = playerOne.chicken.maxHealth;    // Initializes local health tracker to each player's max health
        twoHP = playerTwo.chicken.maxHealth;

        healthBarOne = PopulateArray(oneHP, healthBarOne, new Vector3(-7, -4, 0), step);    // Initializes healthBarOne
        healthBarTwo = PopulateArray(twoHP, healthBarTwo, new Vector3(7, -4, 0), -step);    // Initializes healthBarTwo
    }

    /* Initializes the given |healthBar| array by Instantiating |health| number of egg sprites. 
     * |startPos| marks the position of the first egg on screen, with subsequent eggs a distance |x|
     * apart. The eggs' sorting orders are also set so that the innermost eggs (on screen) render
     * on top.      */
    private GameObject[] PopulateArray(int health, GameObject[] healthBar, Vector3 startPos, float x)
    {
        healthBar = new GameObject[health];
        for (int i = 0; i < health; i++)
        {
            healthBar[i] = Instantiate(eggHP, startPos + new Vector3((x * i), 0), Quaternion.identity);
            healthBar[i].GetComponent<SpriteRenderer>().sortingOrder = i;
        }
        return healthBar;
    }

    // Update is called once per frame
    void Update()
    {
        if (oneHP > playerOne.health)
        {
            UpdateEggs(oneHP, playerOne, healthBarOne);
        }
        if (twoHP > playerTwo.health)
        {
            UpdateEggs(twoHP, playerTwo, healthBarTwo);
        }
    }

    // Updates the |healthBar| array of a player to accurately reflect the player's current health.
    private void UpdateEggs(int thisHealth, Player player, GameObject[] healthBar)
    {
        for (int i = thisHealth - 1; i >= player.health; i--)
        {
            healthBar[i].SetActive(false);
        }

        oneHP = playerOne.health;
    }
}
