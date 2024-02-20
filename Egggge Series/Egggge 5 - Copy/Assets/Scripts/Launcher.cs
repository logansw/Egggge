using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{

    [SerializeField] private Projectile projectile;
    [SerializeField] protected float reloadTime;
    public bool reloaded;

    // Start is called before the first frame update
    void Start()
    {
        reloaded = true;
    }

    public void Shoot()
    {
        if (reloaded)
        {
            Object.Instantiate(projectile).Initialize(this.gameObject.GetComponent<Player>());
            StartCoroutine("IReload");
        }
    }

    IEnumerator IReload()
    {
        reloaded = false;
        yield return new WaitForSeconds(reloadTime);
        reloaded = true;
    }
}
