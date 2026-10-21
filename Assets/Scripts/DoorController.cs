using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Tooltip("The Animator on your door that plays the open animation.")]
    public Animator doorAnimator;

    [Tooltip("The Animator bool parameter name that triggers the open animation.")]
    public string openParameterName = "Open";

    private bool isOpen = false;

    public void UnlockDoor()
    {
        if (isOpen) return;
        isOpen = true;

        if (doorAnimator != null)
            doorAnimator.SetBool(openParameterName, true);
        else
            Debug.LogWarning("DoorController: No Animator assigned!");
    }
}