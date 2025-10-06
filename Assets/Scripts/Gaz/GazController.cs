using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GazController : MonoBehaviour
{
    [Header("Объекты")]
    [SerializeField] private GameObject zond;
    [Header("Канвас")]
    [SerializeField] private TMP_Text gazText;
    [SerializeField] private Image panel;
    [SerializeField] private Color offColor = Color.black;
    [SerializeField] private Color onColor = Color.green;

    private Coroutine gazCoroutine;
    private Coroutine panelCoroutine;
    private bool isGazAnalyzerOn = false;

    public void GazPressed()
    {
        if (!isGazAnalyzerOn)
        {
            if (panelCoroutine != null) StopCoroutine(panelCoroutine);
            panelCoroutine = StartCoroutine(FadePanel(true));
        }

        if (gazCoroutine == null)
        {
            gazCoroutine = StartCoroutine(GazCoroutine());
        }
    }

    public void GazReleased()
    {
        if (gazCoroutine != null)
        {
            StopCoroutine(gazCoroutine);
            gazCoroutine = null;
        }
        if (panelCoroutine != null)
        {
            StopCoroutine(panelCoroutine);
            panel.color = offColor;
            panelCoroutine = null;
        }
    }

    private IEnumerator GazCoroutine()
    {
        Debug.Log("Корутина началась");
        yield return new WaitForSeconds(3f);
        Debug.Log("Что-то делаем");
        OnOffGazAnalyzer();
        gazCoroutine = null;
    }

    public void OnOffGazAnalyzer()
    {
        isGazAnalyzerOn = !isGazAnalyzerOn;

        if (!isGazAnalyzerOn && panel != null)
        {
            if (panelCoroutine != null) StopCoroutine(panelCoroutine);
            panel.color = offColor;
        }
    }

    private IEnumerator FadePanel(bool turnOn)
    {
        Color startColor = panel.color;
        Color endColor = turnOn ? onColor : offColor;
        float duration = 3f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            panel.color = Color.Lerp(startColor, endColor, elapsed / duration);
            yield return null;
        }

        panel.color = endColor;
        panelCoroutine = null;
    }

    private void Update()
    {
        if (zond == null) return;

        if (isGazAnalyzerOn)
        {
            GameObject[] dangerZones = GameObject.FindGameObjectsWithTag("DangerZone");
            float minDistance = float.MaxValue;

            foreach (var zone in dangerZones)
            {
                float distance = Vector3.Distance(zond.transform.position, zone.transform.position);
                if (distance < minDistance)
                    minDistance = distance;
            }

            if (gazText != null)
                gazText.text = $"Расстояние до опасной зоны: {minDistance:F2} м";
        }
    }
}
