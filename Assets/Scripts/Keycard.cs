using UnityEngine;

public class Keycard : MonoBehaviour
{
    //this gives the keycard a ID so that we can even maybe create multiple keycards for specific doors
    [Tooltip("Unique ID for this keycard. The panel must match this to accept it.")]
    public string keycardID = "LabKeycard_01";
}
