using System.Collections;
using UnityEngine;

public class TitleScreenSpawn : MonoBehaviour
{
    [SerializeField] private Transform headset;

    private IEnumerator Start()
    {
        // Allow tracking to supply the headset pose.
        yield return new WaitForSecondsRealtime(0.2f);

        if (headset == null) yield break;

        Vector3 targetPosition = transform.position;
        Vector3 targetForward = transform.forward;
        targetForward.y = 0f;

        Vector3 headForward = headset.forward;
        headForward.y = 0f;

        CharacterController controller =
            GetComponent<CharacterController>();

        bool wasEnabled = controller != null && controller.enabled;
        if (wasEnabled) controller.enabled = false;

        if (headForward.sqrMagnitude > 0.001f &&
            targetForward.sqrMagnitude > 0.001f)
        {
            float angle = Vector3.SignedAngle(
                headForward, targetForward, Vector3.up);

            transform.RotateAround(
                headset.position, Vector3.up, angle);
        }

        Vector3 offset = targetPosition - headset.position;
        offset.y = 0f; // Preserve tracked eye height.
        transform.position += offset;

        if (wasEnabled) controller.enabled = true;
    }
}