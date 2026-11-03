using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup blackOverlay;
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private float blackHold = 0.75f;

    private bool transitioning;

    private void Awake()
    {
        blackOverlay.alpha = 1f;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(blackHold);
        yield return FadeTo(0f);
    }

    public void PlayGame()
    {
        if (transitioning) return;

        transitioning = true;
        StopAllCoroutines();
        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        yield return FadeTo(1f);
        yield return new WaitForSecondsRealtime(0.2f);

        SceneManager.LoadScene("Export scene 2");
    }

    private IEnumerator FadeTo(float target)
    {
        float initial = blackOverlay.alpha;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.unscaledDeltaTime;
            blackOverlay.alpha = Mathf.Lerp(
                initial, target,
                Mathf.Clamp01(elapsed / fadeDuration)
            );
            yield return null;
        }

        blackOverlay.alpha = target;
    }
}
