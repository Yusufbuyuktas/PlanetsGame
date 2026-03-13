using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{  
    RectTransform rectTransform;
    Canvas canvas;
    CanvasGroup canvasGroup;

    Vector2 baslangicPos;

    public bool dogruYereBirakildiMi = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    private void Start()
    {
        baslangicPos = rectTransform.anchoredPosition;
    }
    // sürüklemeye baþlatma
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (dogruYereBirakildiMi)
        {
            return;
        }
      
        canvasGroup.alpha = .5f;
        canvasGroup.blocksRaycasts = false;
       
    }

    // sürükleme aný
    public void OnDrag(PointerEventData eventData)
    {
        if (dogruYereBirakildiMi)
        {
            return;
        }
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        Debug.Log("Sürükleniyor");
    }


    // sürüklemeyi býrakma
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        Debug.Log("Sürükleme bitti");

        if (!dogruYereBirakildiMi)
        {
            rectTransform.anchoredPosition = baslangicPos;
        }
    }
}
