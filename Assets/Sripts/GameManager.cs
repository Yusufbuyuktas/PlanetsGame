using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement; // List kullanabilmek için ekledik

public class GameManager : MonoBehaviour
{
    public int DogruAdet;
    public int YanlisAdet;

    [SerializeField] GameObject one, two, tree;
    [SerializeField] Transform DragObjects; // Bu artýk sahnede duranlar deðil, hiyerarþiyi yönetmek için
    [SerializeField] GameObject Win, Lose;
    // --- YENÝ EKLENENLER ---
    [Header("Gezegen Ayarlarý")]
    public List<GameObject> gezegenPrefablar; // Tüm gezegen prefablarýný buraya sürükle
    public Transform spawnNoktasi;           // Sol taraftaki beyaz alanýn Transform'u
    private GameObject mevcutGezegen;        // O an ekranda olan gezegen
    // -----------------------

    private void Start()
    {
        YeniGezegenGetir();
    }

    public void YeniGezegenGetir()
    {
        if (gezegenPrefablar.Count == 0)
        {
            Debug.Log("Tebrikler! Tüm gezegenleri bildiniz.");
            return;
        }

        // Rastgele bir gezegen seç
        int rastgeleIndex = Random.Range(0, gezegenPrefablar.Count);

        // MevcutGezegen'i spawnNoktasi'nýn çocuðu yapýyoruz
        mevcutGezegen = Instantiate(gezegenPrefablar[rastgeleIndex], spawnNoktasi);

        // Gezegenin ölçeðinin bozulmamasýný ve doðru yerde durmasýný saðlarýz
        RectTransform rect = mevcutGezegen.GetComponent<RectTransform>();
        if (rect != null)
        {
            rect.localPosition = Vector3.zero; // Spawn noktasýnýn tam merkezi
            rect.localScale = Vector3.one;    // Ölçeði (1,1,1) yapar
        }

        // Instantiate edilen nesnenin ismindeki "(Clone)" yazýsýný temizleyelim ki DropPoint ile eþleþsin
        mevcutGezegen.name = gezegenPrefablar[rastgeleIndex].name;

        // Listeden çýkar ki bir daha gelmesin
        gezegenPrefablar.RemoveAt(rastgeleIndex);
    }

    public void DogruArttir()
    {
        DogruAdet++;
        Debug.Log("Doðru! Yeni gezegen hazýrlanýyor...");

        if (DogruAdet == 8)
        {
            Win.SetActive(true);
        }
        else
        {
            // Gezegen doðru yere býrakýldýktan 1 saniye sonra yenisi gelsin
            Invoke("YeniGezegenGetir", 0.8f);
        }
    }

    public void YanlisArttir()
    {
        YanlisAdet++;
        // Mevcut can düþürme mantýðýn (switch-case) aynen kalabilir
        UpdateHearts();

        if (YanlisAdet >= 3)
        {
            Debug.Log("Yanlýþ hakkýnýz bitti!");
            ShutDownTheDrags();
        }
    }

    void UpdateHearts() // Switch-case kýsmýný buraya aldýk
    {
        if (YanlisAdet == 1) one.SetActive(false);
        else if (YanlisAdet == 2) two.SetActive(false);
        else if (YanlisAdet == 3) tree.SetActive(false);
    }

    void ShutDownTheDrags()
    {
        Lose.SetActive(true);
        // Mevcut gezegenin sürüklenmesini kapat
        if (mevcutGezegen != null)
        {
            mevcutGezegen.GetComponent<DragDrop>().enabled = false;
        }
    }
    public void StartAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void DigerSahneyeGec(string sahneAdi)
    {
        SceneManager.LoadScene(sahneAdi);
    }
}