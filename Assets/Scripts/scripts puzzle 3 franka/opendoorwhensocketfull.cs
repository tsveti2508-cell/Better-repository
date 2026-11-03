
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PuzzleDoor : MonoBehaviour
{
    public XRSocketInteractor socket1;
    public XRSocketInteractor socket2;
    public XRSocketInteractor socket3;

    public GameObject correctBall1;
    public GameObject correctBall2;
    public GameObject correctBall3;

    public GameObject door;

    void Update()
    {
        bool correct1 = socket1.hasSelection &&
            socket1.firstInteractableSelected.transform.gameObject == correctBall1;

        bool correct2 = socket2.hasSelection &&
            socket2.firstInteractableSelected.transform.gameObject == correctBall2;

        bool correct3 = socket3.hasSelection &&
            socket3.firstInteractableSelected.transform.gameObject == correctBall3;

        if (correct1 && correct2 && correct3)
        {
            door.SetActive(false);
        }
    }
}
