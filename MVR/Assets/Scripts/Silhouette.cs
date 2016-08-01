using UnityEngine;
using System.Collections;

public class Silhouette : MonoBehaviour
{
    [SerializeField] private AnimationCurve pulseRate;

	[ContextMenu("Pulse")]
	void StartItUp ()
    {
        StartCoroutine(HighLightPulse(1));
	}

    IEnumerator HighLightPulse(float time)
    {
        while (true)
        {
            float timer = 0;
            while (timer <= time)
            {
                transform.localScale = new Vector3(pulseRate.Evaluate(timer / time), pulseRate.Evaluate(timer / time), pulseRate.Evaluate(timer / time));
                timer += Time.deltaTime;
                yield return null;
            }
            yield return null;
        }
    }
}
