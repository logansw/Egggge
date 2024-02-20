using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    private static CharacterSelect instance = null;

    [SerializeField] private Chicken[] chickens;
    private int playerOneIndex;
    private int playerTwoIndex;

    [SerializeField] private Text playerOneText;
    [SerializeField] private Image playerOneImage;
    [SerializeField] private Text playerTwoText;
    [SerializeField] private Image playerTwoImage;

    public Chicken chickenOne;
    public Chicken chickenTwo;

    private bool oneReady;
    private bool twoReady;

    public static CharacterSelect Instance
    {
        get { return instance; }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;

        StartCoroutine("Initialize");

        oneReady = false;
        twoReady = false;

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Select();
        LockIn();
        LoadScene();
    }

    private void Select()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerOneIndex = CycleChicken(playerOneIndex, 1, playerOneText, playerOneImage);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            playerOneIndex = CycleChicken(playerOneIndex, -1, playerOneText, playerOneImage);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerTwoIndex = CycleChicken(playerTwoIndex, 1, playerTwoText, playerTwoImage);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerTwoIndex = CycleChicken(playerTwoIndex, -1, playerTwoText, playerTwoImage);
        }
    }

    private void LockIn()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            chickenOne = chickens[playerOneIndex];
            oneReady = true;
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            chickenTwo = chickens[playerTwoIndex];
            twoReady = true;
        }
    }

    private void LoadScene()
    {
        if (oneReady && twoReady)
        {
            oneReady = false;
            twoReady = false;
            SceneManager.LoadScene("MainStage");
            this.enabled = false;
        }
    }

    private int CycleChicken(int index, int change, Text text, Image image)
    {
        index = index + change;
        if (index > chickens.Length - 1)
        {
            index = 0;
        }
        else if (index < 0)
        {
            index = chickens.Length - 1;
        }
        Chicken chicken = chickens[index];

        text.text = index.ToString() + chicken.gameObject.name;
        image.sprite = chicken.gameObject.GetComponent<SpriteRenderer>().sprite;

        return index;
    }

    public IEnumerator Initialize()     // This coroutine is used to work around an issue where references were being drawn before objects were actually instantiated in the scene. This is sketchy but it works
    {
        yield return new WaitForSeconds(0.1f);
        // Grab all UI references
        playerOneText = GameObject.Find("playerOneText").GetComponent<Text>();
        playerOneImage = GameObject.Find("playerOneImage").GetComponent<Image>();
        playerTwoText = GameObject.Find("playerTwoText").GetComponent<Text>();
        playerTwoImage = GameObject.Find("playerTwoImage").GetComponent<Image>();

        playerOneIndex = -1;    // Initialized at -1 so that when we call CycleChicken once, it starts at index 0.
        playerTwoIndex = -1;
        playerOneIndex = CycleChicken(playerOneIndex, 1, playerOneText, playerOneImage);
        playerTwoIndex = CycleChicken(playerTwoIndex, 1, playerTwoText, playerTwoImage);
    }
}
