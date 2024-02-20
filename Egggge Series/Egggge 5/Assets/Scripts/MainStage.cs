using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStage : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        // Spawn 2 Players
        CharacterSelect characterSelect = FindObjectOfType<CharacterSelect>();
        Chicken chickenOne = characterSelect.chickenOne;
        Chicken chickenTwo = characterSelect.chickenTwo;

        Vector3 spawnOne = new Vector3(-6.5f, 6, 0);
        Vector3 spawnTwo = new Vector3(6.5f, 6, 0);

        chickenOne = SpawnChicken(spawnOne, chickenOne);
        chickenTwo = SpawnChicken(spawnTwo, chickenTwo);

        AddPlayerComponent(chickenOne.gameObject, KeyCode.W, KeyCode.A, KeyCode.D, KeyCode.S, chickenOne, Player.Direction.Right);
        AddPlayerComponent(chickenTwo.gameObject, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.DownArrow, chickenTwo, Player.Direction.Left);

        chickenTwo.GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);

        chickenOne.gameObject.name = "PlayerOne";
        chickenTwo.gameObject.name = "PlayerTwo";
    }

    private Chicken SpawnChicken(Vector3 spawnPos, Chicken chicken)
    {
        return Instantiate(chicken, spawnPos, Quaternion.identity);
    }

    private void AddPlayerComponent(GameObject obj, KeyCode jumpKey, KeyCode fireA, KeyCode fireB, KeyCode fallKey, Chicken chicken, Player.Direction dir)
    {
        Player player = obj.AddComponent<Player>();
        player.jumpKey = jumpKey;
        player.fireA = fireA;
        player.fireB = fireB;
        player.fallKey = fallKey;
        player.chicken = chicken;
        player.dir = dir;
    }
}
