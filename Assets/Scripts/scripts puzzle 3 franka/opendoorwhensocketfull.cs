using UnityEngine;
using UnityEngine.Events;
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

    public UnityEvent onSolved = new UnityEvent();

    private bool solved;

    private void Update()
    {
        if (solved) return;

        bool correct1 = IsCorrect(socket1, correctBall1);
        bool correct2 = IsCorrect(socket2, correctBall2);
        bool correct3 = IsCorrect(socket3, correctBall3);

        if (correct1 && correct2 && correct3)
        {
            solved = true;

            if (door != null)
        

            onSolved.Invoke();
        }
    }

    private bool IsCorrect(
        XRSocketInteractor socket, GameObject correctObject)
    {
        return socket != null &&
               correctObject != null &&
               socket.hasSelection &&
               socket.firstInteractableSelected.transform.gameObject
                   == correctObject;
    }
}