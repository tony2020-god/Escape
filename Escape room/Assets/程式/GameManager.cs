using UnityEngine;
using System.Collections;//引用系統集合、管理API(協同程式:非同步處理)
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image loading;
    public float imageCD = 0.9f;
    [Header("遊戲載入畫面")]
    public GameObject gameView;
    public static GameManager instance; //對戰管理實體物件


    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        StartCoroutine(Startloadingimage());
    }
    public IEnumerator Startloadingimage()
    {
        yield return new WaitForSeconds(0.5f);
        while (imageCD > 0)        //迴圈 while(布林值) "當布林值為 true 時執行敘述"
        {

            imageCD = imageCD - 0.01f;
            loading.fillAmount = imageCD / 0.9f;                            //更新載入吧條
                                                                            //等待
            if (imageCD <= 0)    //判斷式 if(布林值) "當布林值為true時執行一次"  
            {
                gameView.SetActive(false); //關閉遊戲載入畫面
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    public IEnumerator Endloadingimage()
    {

        gameView.SetActive(true); //關閉遊戲載入畫面
        while (imageCD < 1)        //迴圈 while(布林值) "當布林值為 true 時執行敘述"
        {

            imageCD = imageCD + 0.01f;
            loading.fillAmount = imageCD / 0.9f;                            //更新載入吧條
            yield return new WaitForSeconds(0.01f);
        }
    }
}
