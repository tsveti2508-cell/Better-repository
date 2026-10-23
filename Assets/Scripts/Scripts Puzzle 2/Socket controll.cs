using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Socketcontroll : MonoBehaviour
{
    public XRSocketInteractor socket;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();

    }

    public void SocketCheck()
    {
        GameObject item = socket.selectTarget.gameObject;
        if (item.CompareTag("Yellow"));
        {
            Debug.Log "Right Harddrive has been put in"
        
        }
    }

}
