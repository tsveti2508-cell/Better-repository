using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutsceneTrigger : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Transform screen;                  // the Quad
    public string nextSceneName = "NextScene";
    public GameObject locomotion;
public GameObject[] hideDuringCutscene; // Left Hand, Right Hand
    public float screenDistance = 2.5f;
    public string cutsceneLayer = "Cutscene";

    bool played;
void Start()
{
    videoPlayer.Prepare();
}
    void OnTriggerEnter(Collider other)
    { 
    Debug.Log("Trigger touched by: " + other.name + " tag: " + other.tag);

    if (played || !other.transform.root.CompareTag("Player")) return;
    played = true;
        if (played || !other.CompareTag("Player")) return;
        played = true;

        if (locomotion != null) locomotion.SetActive(false);
foreach (var go in hideDuringCutscene) go.SetActive(false);
        Camera cam = Camera.main;
        screen.SetParent(cam.transform, false);
        screen.localPosition = new Vector3(0, 0, screenDistance);
        screen.localRotation = Quaternion.Euler(0, 180, 0); // use Quaternion.identity if the video looks flipped
        screen.gameObject.SetActive(true);

        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = Color.black;
        cam.cullingMask = 1 << LayerMask.NameToLayer(cutsceneLayer);

        videoPlayer.loopPointReached += OnVideoFinished;
        videoPlayer.Play();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        vp.loopPointReached -= OnVideoFinished;
        SceneManager.LoadScene(nextSceneName);
    }
}