using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    private void Start()
    {
        gameObject.AddComponent<BoxCollider>();
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        //print($"particles collided with {other.name}");
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
