using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;//引用系統集合、管理API(協同程式:非同步處理)

public class MenuManager : MonoBehaviour
{
  
    
    public GameObject background;
    public Animator ani;
    public GameObject runtext;
    public GameObject chicktext;
    public void StartGame()
    {
        SceneManager.LoadScene("關卡1");
    }
    public IEnumerator ButtunChick()
    {
        print("123");
        ani.SetBool("點擊開始遊戲", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(runtext);
        Destroy(chicktext);
        Invoke("StartGame", 3f);
    }
    public void buttonclick()
    {
        StartCoroutine(ButtunChick());
    }
}
