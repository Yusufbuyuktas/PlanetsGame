using UnityEngine;


public class GameManager : MonoBehaviour
{
    public int DogruAdet;
    public int YanlisAdet;

    [SerializeField] GameObject one, two, tree;

    [SerializeField] Transform DragObjects;
    public void DogruArttir()
    {
        DogruAdet++;
        if (DogruAdet == 8)
        {
            Debug.Log("Tebrikler! Tüm doðru parçalarý yerleþtirdiniz.");
        }
        else
        {
            Debug.Log("Doðru! Kalan doðru parçalar: " + (8 - DogruAdet));
        }
    }
    public void YanlisArttir()
    {
        YanlisAdet++;
        switch (YanlisAdet)
        {
                case 1:
                    one.SetActive(false);
                    break;
                case 2:
                    two.SetActive(false);
                    break;
                case 3:
                    tree.SetActive(false);
                    break;
                default:
                    break;
        }
        if (YanlisAdet == 3)
        {
            Debug.Log("Yanlýþ hakkýnýz bitti ");
            Invoke("ShutDownTheDrags", 1f);
        }
        else
        {
            Debug.Log("Yanlýþ! Kalan yanlýþ haklar: " + (3 - YanlisAdet));

        }
    }
    void ShutDownTheDrags()
    {

            foreach (Transform child in DragObjects)
            {
                child.GetComponent<DragDrop>().enabled = false;
            }
    }
}
