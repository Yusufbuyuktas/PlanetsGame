using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuManager : MonoBehaviour
{
   
    public void OyunuBaslat()
    {
       
        SceneManager.LoadScene("(1)GameScene");
    }

    
    public void OyundanCik()
    {
        Debug.Log("Oyundan çýkýldý."); 
        Application.Quit();
    }
}