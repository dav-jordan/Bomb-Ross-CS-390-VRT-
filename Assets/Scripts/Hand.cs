using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour
{
    public SteamVR_Action_Boolean GrabAction = null;
    public Explodes explodes;

    private SteamVR_Behaviour_Pose Pose = null;
    private FixedJoint Joint = null;

    private Interactable CurrentInteractable = null;
    private List<Interactable> ContactInteractables = new List<Interactable>();

    public AudioSource GetCrazy;

    public bool holding = false;
    public GameObject OtherController;

    void Awake() {
        Pose = GetComponent<SteamVR_Behaviour_Pose>();
        Joint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        // We will now begin the push up section. Ready? Begin!

        // Down
        if (GrabAction.GetLastStateDown(Pose.inputSource)) {
            print(Pose.inputSource + " Trigger down");
            Pickup();
        }

        // Up
        if (GrabAction.GetLastStateUp(Pose.inputSource))
        {
            print(Pose.inputSource + " Trigger up");
            Drop();
        }
    }

    // Pickup object
    public void Pickup() {
        CurrentInteractable = GetNearestInteractable();
        if (!CurrentInteractable)
            return;
        if (CurrentInteractable.ActiveHand)
            CurrentInteractable.ActiveHand.Drop();
        CurrentInteractable.transform.position = transform.position;
        Rigidbody targetBody = CurrentInteractable.GetComponent<Rigidbody>();
        Joint.connectedBody = targetBody;
        CurrentInteractable.ActiveHand = this;
        holding = true;
        bool otherHolding = OtherController.GetComponent<Hand>().holding;
        if (otherHolding)
            GetCrazy.Play();
    }

    // Drop object
    public void Drop() {
        if (!CurrentInteractable)
            return;
        Rigidbody target = CurrentInteractable.GetComponent<Rigidbody>();
        target.velocity = Pose.GetVelocity() * 2;
        target.angularVelocity = Pose.GetAngularVelocity();
        print(target.velocity);
        Joint.connectedBody = null;
        CurrentInteractable.ActiveHand = null;
        CurrentInteractable = null;
        holding = false;
    }

    private Interactable GetNearestInteractable() {
        Interactable nearest = null;
        float min = float.MaxValue;
        float distance = 0.0f;

        foreach (Interactable interactable in ContactInteractables) {
            distance = (interactable.transform.position - transform.position).sqrMagnitude;

            if (distance < min) {
                min = distance;
                nearest = interactable;
            }
        }
        return nearest;
    }
    private void OnTriggerEnter(Collider other) {
        if (!other.gameObject.CompareTag("Interactable"))
            return;
        print("Adding object");
        ContactInteractables.Add(other.gameObject.GetComponent<Interactable>());
    }

    private void OnTriggerExit(Collider other) {
        if (!other.gameObject.CompareTag("Interactable"))
            return;
        ContactInteractables.Remove(other.gameObject.GetComponent<Interactable>());
    }
}
