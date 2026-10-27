using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
public class ComputerMonitorController : MonoBehaviour
{
    [Header("Hard Drive Sockets")]
    public XRSocketInteractor yellowSocket;
    public XRSocketInteractor redSocket;
    public XRSocketInteractor blueSocket;
    [Header("Monitor")]
    public GameObject monitorScreen;
    public Light monitorLight;
    [Header("Number Slide Puzzle")]
    public GameObject numberSlidePuzzle;
    private bool monitorOn = false;
    void Start()
    {
        TurnOffMonitor();
    }
    void Update()
    {
        bool yellow = CheckSocket(yellowSocket, "Yellow");
        bool red = CheckSocket(redSocket, "Red");
        bool blue = CheckSocket(blueSocket, "Blue");
        bool allCorrect = yellow && red && blue;
        if (allCorrect && !monitorOn)
        {
            TurnOnMonitor();
        }
        else if (!allCorrect && monitorOn)
        {
            TurnOffMonitor();
        }
    }
    bool CheckSocket(XRSocketInteractor socket, string tagName)
    {
        if (socket == null)
        {
            Debug.LogError(tagName + " socket is not assigned!");
            return false;
        }

        if (socket.interactablesSelected.Count == 0)
        {
            Debug.Log(tagName + " socket is empty.");
            return false;
        }

        GameObject drive =
            socket.interactablesSelected[0].transform.gameObject;

        Debug.Log(tagName + " socket detects: " +
                  drive.name + " | Tag: " + drive.tag);

        return drive.CompareTag(tagName);
    }

    void TurnOnMonitor()
    {
        monitorOn = true;
        if (monitorScreen != null)
            monitorScreen.SetActive(true);
        if (monitorLight != null)
            monitorLight.enabled = true;
        if (numberSlidePuzzle != null)
            numberSlidePuzzle.SetActive(true);
        Debug.Log("MONITOR ON - NUMBER SLIDE ACTIVATED!");
    }
    void TurnOffMonitor()
    {
        monitorOn = false;
        if (numberSlidePuzzle != null)
            numberSlidePuzzle.SetActive(false);
        if (monitorScreen != null)
            monitorScreen.SetActive(false);
        if (monitorLight != null)
            monitorLight.enabled = false;
    }
}

    
