using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private int speed;
    [SerializeField] private int damage;

    private Vector3 dir;
    

    // Start is called before the first frame update
    void Start()
    {
       dir = new Vector3(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + dir;
    }
}
