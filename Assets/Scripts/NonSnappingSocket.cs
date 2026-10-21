using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

// this custom socket detects an overlap but does not grab/snap the keycard so that it makes it like the player is more in control of their body.
public class NonSnappingSocket : XRSocketInteractor
{
    // returning false means that the socket will not "select" (snap) the interactable to the panel.
    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return false;
    }

    //Still want the know when things are entering the socket's hovering zone
    public override bool CanHover(IXRHoverInteractable interactable)
    {
        return base.CanHover(interactable);
    }
}
