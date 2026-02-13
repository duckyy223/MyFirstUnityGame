using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour
{
    RectTransform rt;
    Image img;

    Vector2 appliedMove;
    float appliedRotation;
    float appliedScale;

    bool jugando = false;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
        img = GetComponent<Image>();

        Debug.Log("🧠 AWAKE ================================");
        Debug.Log("GameObject: " + gameObject.name);
        Debug.Log("Parent: " + transform.parent.name);
        Debug.Log("Anchors: " + rt.anchorMin + " -> " + rt.anchorMax);
        Debug.Log("Pivot: " + rt.pivot);
        Debug.Log("Initial anchoredPosition: " + rt.anchoredPosition);
        Debug.Log("Has Image: " + (img != null));

        if (transform.parent.GetComponent<LayoutGroup>() != null)
            Debug.LogError("🚨 PARENT HAS LAYOUT GROUP → MOVEMENT WILL BE OVERRIDDEN");

        if (transform.parent.GetComponent<ContentSizeFitter>() != null)
            Debug.LogError("🚨 PARENT HAS CONTENT SIZE FITTER → MOVEMENT WILL BE OVERRIDDEN");

        Debug.Log("🧠 END AWAKE ============================");
    }

    public void Jugar()
    {
        Debug.Log("🔥 JUGAR() PULSADO =====================");
        Debug.Log("Before start anchoredPosition: " + rt.anchoredPosition);

        jugando = true;
        StopAllCoroutines();
        StartCoroutine(BRAINROT_DEBUG());

        Debug.Log("Coroutine started");
    }

    IEnumerator BRAINROT_DEBUG()
    {
        int frame = 0;

        while (jugando && frame < 300)
        {
            frame++;

            // ================= FUERZAS =================
            appliedMove = new Vector2(
                Mathf.Sin(Time.time * 6f),
                Mathf.Cos(Time.time * 4f)
            ) * 50f;

            appliedRotation =
                Mathf.Sin(Time.time * 8f) * 180f;

            appliedScale =
                1f + Mathf.Sin(Time.time * 5f) * 0.3f;

            // ================= APLICAR =================
            Vector2 beforePos = rt.anchoredPosition;
            float beforeRot = rt.localEulerAngles.z;
            Vector3 beforeScale = rt.localScale;

            rt.anchoredPosition += appliedMove * Time.deltaTime;
            rt.Rotate(0, 0, appliedRotation * Time.deltaTime);
            rt.localScale = Vector3.one * appliedScale;

            // ================= LOG HIPER =================
            Debug.Log(
                "🧪 FRAME " + frame +
                "\n  AppliedMove: " + appliedMove +
                "\n  Position BEFORE: " + beforePos +
                "\n  Position AFTER: " + rt.anchoredPosition +
                "\n  ΔPosition: " + (rt.anchoredPosition - beforePos) +
                "\n  Rotation BEFORE: " + beforeRot +
                "\n  Rotation AFTER: " + rt.localEulerAngles.z +
                "\n  Scale BEFORE: " + beforeScale +
                "\n  Scale AFTER: " + rt.localScale
            );

            yield return null;
        }

        Debug.Log("💀 BRAINROT_DEBUG TERMINATED");
    }
}
