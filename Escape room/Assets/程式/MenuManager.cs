using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
  
    
    public GameObject background;
    public Animator ani;

    public void StartGame()
    {
        
        SceneManager.LoadScene("關卡1");
    }
    public void ButtunChick()
    {
        print("123");
        
        ani.SetBool("點擊開始遊戲", true);
        Invoke("StartGame", 3f);
    }
}
