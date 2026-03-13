using UnityEngine;
using UnityEngine.EventSystems;

public class DropPoint : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject BirakilanNesne = eventData.pointerDrag;
        if (BirakilanNesne != null )
        {
            DragDrop dragDrop = BirakilanNesne.GetComponent<DragDrop>();

            if (dragDrop.name == gameObject.name)
            {
                dragDrop.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                dragDrop.dogruYereBirakildiMi = true;
                dragDrop.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
            else
            {
                Debug.Log("Býrakýlan nesne null veya yanlýþ nesne!");
            }
        }
        
    }


}
