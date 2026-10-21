using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

[RequireComponent(typeof(NonSnappingSocket))]
public class KeycardPanel : MonoBehaviour
{
    [Header("Panel Settings")]
    [Tooltip("The ID this panel will accept.")]
    public string requiredKeycardID = "LabKeycard_01";

    [Tooltip("Only allow the panel to be used once.")]
    public bool oneTimeUse = true;

    [Header("Feedback")]
    [Tooltip("Optional: a light or renderer to change color on success.")]
    public Renderer statusLight;
    public Color idleColor = Color.red;
    public Color successColor = Color.green;

    [Header("Events")]
    public UnityEvent onCorrectCardInserted;
    public UnityEvent onWrongCardInserted;

    private NonSnappingSocket socket;
    private bool hasBeenUnlocked = false;

    private void Awake()
    {
        socket = GetComponent<NonSnappingSocket>();
        socket.hoverEntered.AddListener(OnHoverEntered);

        if (statusLight != null)
            statusLight.material.color = idleColor;
    }

    private void OnDestroy()
    {
        if (socket != null)
            socket.hoverEntered.RemoveListener(OnHoverEntered);
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        if (hasBeenUnlocked && oneTimeUse) return;

        Keycard card = args.interactableObject.transform.GetComponent<Keycard>();

        if (card == null)
            return;

        if (card.keycardID == requiredKeycardID)
        {
            Unlock();
        }
        else
        {
            Debug.Log($"Wrong keycard: {card.keycardID}. Panel requires {requiredKeycardID}.");
            onWrongCardInserted?.Invoke();
        }
    }

    private void Unlock()
    {
        hasBeenUnlocked = true;

        if (statusLight != null)
            statusLight.material.color = successColor;

        Debug.Log("Correct keycard detected. Unlocking.");
        onCorrectCardInserted?.Invoke();
    }
}