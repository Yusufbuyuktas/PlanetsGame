using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropPoint : MonoBehaviour,IDropHandler
{

    GameManager gameManager;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    public void OnDrop(PointerEventData eventData)
    {
         UnityEngine.GameObject BirakilanNesne = eventData.pointerDrag;
        if (BirakilanNesne != null )
        {
            DragDrop dragDrop = BirakilanNesne.GetComponent<DragDrop>();

            if (dragDrop.name == gameObject.name)
            {
                dragDrop.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                dragDrop.dogruYereBirakildiMi = true;
                dragDrop.GetComponent<CanvasGroup>().blocksRaycasts = false;
                gameManager.DogruArttir();
            }
            else
            {
                gameManager.YanlisArttir();
                Debug.Log("Býrakýlan nesne null veya yanlýþ nesne!");

            }
        }
        
    }


}
