using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTutorialCheck : MonoBehaviour
{
    public KeyCode keyToCheck;
    public string playerName;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find(playerName).GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isGrounded && Input.GetKeyDown(keyToCheck))
        {
            this.gameObject.SetActive(false);
        }
    }
}
