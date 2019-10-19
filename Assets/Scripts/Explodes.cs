using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodes : MonoBehaviour
{
    public Transform SpawnPosition;
    public GameObject splatter;
    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("ExplodesBomb") && !collision.gameObject.CompareTag("Canvas"))
            return;
        Transform prevPosition = this.transform;
        // Add splatter sprite
        if (splatter != null && collision.gameObject.CompareTag("Canvas"))
        {
            Instantiate(splatter, prevPosition.position, Quaternion.FromToRotation(Vector3.up, collision.gameObject.transform.rotation.eulerAngles));
        }
        this.transform.position = SpawnPosition.position;
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

    }
}
