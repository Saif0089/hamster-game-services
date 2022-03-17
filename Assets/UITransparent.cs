using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITransparent : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public float normalAlpha;
    public float pressedAlpha;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = normalAlpha;
    }

    public void MakeUITransparent()
    {
        canvasGroup.alpha = normalAlpha;
    }
    
    public void MakeUIOpaque()
    {
        canvasGroup.alpha = pressedAlpha;
    }
}
