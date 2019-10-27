using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodes : MonoBehaviour
{
    public Transform SpawnPosition;
    public GameObject splatter;
    public AudioSource SplatSound;
    public AudioSource BeatTheDevil;
    public bool Sound;

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("ExplodesBomb") && !collision.gameObject.CompareTag("Table") && !collision.gameObject.CompareTag("Canvas"))
            return;
        Vector3 prevPosition = this.transform.position;
        // Add splatter sprite
        if (splatter != null && collision.gameObject.CompareTag("Canvas"))
        {
            Instantiate(splatter, prevPosition, collision.gameObject.transform.rotation);
            this.transform.position = SpawnPosition.position;
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            SplatSound.Play();
        }
        else if (collision.gameObject.CompareTag("Table")) {
            print(this.GetComponent<Rigidbody>().velocity);
            Vector3 velocity = this.GetComponent<Rigidbody>().velocity;
            if (velocity.y <= -0.15f)
                BeatTheDevil.Play();
        }
        else
        {
            this.transform.position = SpawnPosition.position;
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }

    }

}
