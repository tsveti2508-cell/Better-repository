using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyholeTrigger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private XRSocketInteractor socket;  // The Socket Interactor child
    [SerializeField] private Animator boxAnimator;       // The Front object's Animator

    [Header("Settings")]
    [SerializeField] private string openTrigger = "KeyOpen";
    [SerializeField] private string keyTag = "Key";

    private bool opened = false;

    private void OnEnable()
    {
        Debug.Log("KeyholeTrigger enabled, socket = " + socket);
        if (socket != null)
            socket.selectEntered.AddListener(OnKeyInserted);
    }

    private void OnDisable()
    {
        if (socket != null)
            socket.selectEntered.RemoveListener(OnKeyInserted);
    }

    private void OnKeyInserted(SelectEnterEventArgs args)
    {
        Debug.Log("Keyhole triggered by: " + args.interactableObject.transform.name);

        if (opened) return;
        if (!args.interactableObject.transform.CompareTag(keyTag)) return;

        opened = true;
        boxAnimator.SetTrigger(openTrigger);
    }
}