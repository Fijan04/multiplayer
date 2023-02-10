using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float timer;

    void Update()
    {
        Invoke("Die", timer);
    }
    private void Die()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Neprijatelj")
        {
            Destroy(this.gameObject);
        }
    }
}
