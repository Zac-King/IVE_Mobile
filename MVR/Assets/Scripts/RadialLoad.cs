using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Image))]
public class RadialLoad : MonoBehaviour
{
    #region Variables
    private Image m_progressCircle;                     // 
    [SerializeField] private float m_loadTime = 3f;     // Seconds to complete load
    [SerializeField] private Gradient m_loadGradient;   // Gradient over time for load
    public bool m_loading = false;                      // Bool for current state of loading 
   
    #endregion
    // MonoBehaviour ///////////////////////////////////////////////////////////////////////////////////
    void Awake()    // If not already set up, it will be fixed on awake
    {
        m_progressCircle = gameObject.GetComponent<Image>();
        m_progressCircle.type = Image.Type.Filled;
    }
    
    // Context Menu Functions //////////////////////////////////////////////////////////////////////////
    [ContextMenu("Set the Type to Fill")]   // Set image type without having to play scene
    private void Setup()
    {
        m_progressCircle = gameObject.GetComponent<Image>();
        m_progressCircle.type = Image.Type.Filled;
    }

    [ContextMenu("Test Load")]
    private void testLoad()                 // Simulate an outside function influence on script
    {
        Callback c = assdf;
        m_loading = true;
        LoadTarget(3, c);
    }

    void assdf()
    {
        Debug.Log("Loading complete");
    }
    
    // Functions ///////////////////////////////////////////////////////////////////////////////////////
    public void LoadTarget(float loadTime, Callback a)
    {
        m_loadTime = loadTime;
        StartCoroutine(LoadCircle(a));
    }

    IEnumerator LoadCircle(Callback callback)    // Load coroutine
    {
        float timer = 0;
        while (timer <= m_loadTime && m_loading)
        {
            m_progressCircle.fillAmount = timer / m_loadTime;
            m_progressCircle.color = m_loadGradient.Evaluate(timer / m_loadTime);
            timer += Time.deltaTime;
            yield return null;
        }

        if(m_loading)
        {
            callback();
        }

        m_progressCircle.fillAmount = 0;   // Reset
    }
}
