using UnityEngine;

public class wiresocket : MonoBehaviour
{
    public int socketID;
    public bool isOccupied = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isOccupied) return;

        wire wire = other.GetComponentInParent<wire>();

        if (wire == null) return;

        if (wire.wireID == socketID)
        {
            wire.Connect(transform);
            isOccupied = true;

            //PuzzleManager.Instance.CheckPuzzle();
            if (PuzzleManager.Instance != null)
            {
                PuzzleManager.Instance.CheckPuzzle();
            }
            else
            {
                Debug.LogWarning("PuzzleManager is missing!");
            }
        }
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
