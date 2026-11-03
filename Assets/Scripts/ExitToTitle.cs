using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class ExitToTitle : MonoBehaviour
{
    [SerializeField] private Transform headset;
    [SerializeField] private CanvasGroup blackOverlay;
    [SerializeField] private string titleSceneName = "Title Screen";
    [SerializeField] private float fadeDuration = 0.75f;
    [SerializeField] private float blackHold = 1.5f;

    private BoxCollider exitZone;
    private bool leaving;

    private void Awake()
    {
        exitZone = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (leaving || headset == null || blackOverlay == null)
            return;

        Vector3 point =
            transform.InverseTransformPoint(headset.position)
            - exitZone.center;

        Vector3 halfSize = exitZone.size * 0.5f;

        bool inside =
            Mathf.Abs(point.x) <= halfSize.x &&
            Mathf.Abs(point.y) <= halfSize.y &&
            Mathf.Abs(point.z) <= halfSize.z;

        if (inside)
        {
            leaving = true;
            StartCoroutine(ReturnToTitle());
        }
    }

    private IEnumerator ReturnToTitle()
    {
        float initialAlpha = blackOverlay.alpha;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.unscaledDeltaTime;

            blackOverlay.alpha = Mathf.Lerp(
                initialAlpha,
                1f,
                Mathf.Clamp01(elapsed / fadeDuration)
            );

            yield return null;
        }

        blackOverlay.alpha = 1f;

        yield return new WaitForSecondsRealtime(blackHold);

        SceneManager.LoadScene(titleSceneName);
    }
}
