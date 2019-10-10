using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("ExplodesBomb"))
            return;
        Destroy(gameObject);

        // TODO: Add code to splatter bomb
    }
}
