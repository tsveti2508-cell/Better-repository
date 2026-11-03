using UnityEngine;

public class wire : MonoBehaviour
{

    public int wireID;
    public bool isConnected = false;

    public void Connect(Transform socket)
    {
        isConnected = true;

        transform.SetPositionAndRotation(
            socket.position,
            socket.rotation
            );
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
