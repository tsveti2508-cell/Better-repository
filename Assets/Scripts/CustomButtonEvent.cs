using UnityEngine;
using UnityEngine.UIElements;

public class CustomButtonEvent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button resumeButton = root.Q<Button>("resumeButton");
        Button restartButton = root.Q<Button>("restartButton");
        Button quitButton = root.Q<Button>("quitButton");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
