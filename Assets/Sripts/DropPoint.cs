using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections; // Coroutine (animasyon) için bu þart

public class DropPoint : MonoBehaviour, IDropHandler
{
    GameManager gameManager;

    [Header("Level Özel Ayarlarý")]
    [Tooltip("Gezegen doðru yere geldiðinde hangi boyuta ulaþsýn? (Örn: 0.7, 0.7, 1)")]
    public Vector3 hedefOlcek = Vector3.one;

    [Tooltip("Küçülme/Büyüme animasyonu ne kadar sürsün?")]
    public float animasyonSuresi = 0.4f;

    private void Start()
    {
        // GameManager'ý sahnede buluyoruz
        gameManager = Object.FindFirstObjectByType<GameManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject BirakilanNesne = eventData.pointerDrag;

        if (BirakilanNesne != null)
        {
            DragDrop dragDrop = BirakilanNesne.GetComponent<DragDrop>();

            // 1. Script kontrolü ve Ýsim kontrolü
            if (dragDrop != null && dragDrop.name == gameObject.name)
            {
                // Doðru yer! Pozisyonu tam merkeze eþitle
                dragDrop.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;

                // Gezegeni yuvanýn içine taþý (Hiyerarþi düzeni için iyi olur)
                dragDrop.transform.SetParent(this.transform);

                // Durum deðiþkenlerini güncelle
                dragDrop.dogruYereBirakildiMi = true;

                if (dragDrop.GetComponent<CanvasGroup>() != null)
                {
                    dragDrop.GetComponent<CanvasGroup>().blocksRaycasts = false;
                }

                // 2. Ölçeklendirme Animasyonunu Baþlat
                RectTransform rect = dragDrop.GetComponent<RectTransform>();
                StartCoroutine(OlceklendirmeAnimasyonu(rect, hedefOlcek));

                // GameManager'a bildir
                if (gameManager != null) gameManager.DogruArttir();
            }
            else
            {
                // Yanlýþ yer!
                if (gameManager != null) gameManager.YanlisArttir();
                Debug.Log("Yanlýþ nesne býrakýldý veya DragDrop scripti eksik!");
            }
        }
    }

    // Gezegeni yumuþak bir þekilde büyüten veya küçülten fonksiyon
    IEnumerator OlceklendirmeAnimasyonu(RectTransform hedefRect, Vector3 hedefBoyut)
    {
        Vector3 baslangicOlcegi = hedefRect.localScale;
        float gecenSure = 0f;

        while (gecenSure < animasyonSuresi)
        {
            gecenSure += Time.deltaTime;
            // Lerp ile baþlangýçtan hedefe yumuþak geçiþ
            hedefRect.localScale = Vector3.Lerp(baslangicOlcegi, hedefBoyut, gecenSure / animasyonSuresi);
            yield return null; // Bir sonraki kareyi bekle
        }

        // Deðeri tam olarak hedefe sabitle
        hedefRect.localScale = hedefBoyut;
    }
}