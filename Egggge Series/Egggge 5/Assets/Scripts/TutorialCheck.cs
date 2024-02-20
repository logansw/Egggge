using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCheck : MonoBehaviour
{
    public KeyCode keyToCheck;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToCheck))
        {
            this.gameObject.SetActive(false);
        }
    }
}
