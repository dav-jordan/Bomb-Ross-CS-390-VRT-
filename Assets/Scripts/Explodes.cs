using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodes : MonoBehaviour
{
    public Transform SpawnPosition;
    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("ExplodesBomb"))
            return;
        this.transform.position = SpawnPosition.position;
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        // TODO: Add code to splatter bomb
    }
}
