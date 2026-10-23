using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Socketcontroll : MonoBehaviour
{
    [Header("Socket Settings")]
    public XRSocketInteractor socket;

    private void Start()
    {
        if (socket == null)
        {
            socket = GetComponent<XRSocketInteractor>();
        }

        if (socket == null)
        {
            Debug.LogError("Socketcontroll: No XRSocketInteractor found!");
        }
    }

    public void SocketCheck()
    {
        if (socket == null)
        {
            Debug.LogWarning("Socketcontroll: Socket is not assigned.");
            return;
        }

        if (socket.interactablesSelected.Count == 0)
        {
            Debug.Log("No hard drive is selected in the socket.");
            return;
        }

        var selectedInteractable = socket.interactablesSelected[0];
        GameObject item = selectedInteractable.transform.gameObject;

        if (item.CompareTag("Yellow"))
        {
            Debug.Log("Right Harddrive has been put in");
        }
        else
        {
            Debug.Log("Wrong hard drive: " + item.name);
        }
    }
}
