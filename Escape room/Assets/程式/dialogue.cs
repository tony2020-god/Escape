using UnityEngine.UI;
using UnityEngine;

public class dialogue : MonoBehaviour
{
    public float charsPerSecond = 0.2f;//打字時間間隔
    public string[] words = { "房間被上鎖了" }; //保存需要顯示的文字
    public int strindex = 0;//控制語句
    public static dialogue instance; //對戰管理實體物件
    private bool isActive = false;
    private float timer;//計時器
    public Text myText;
    public GameObject Dia;
    public int currentPos = 0;//當前打字位置

    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        timer = 0;
        
    }
    public void Update()
    {
        OnStartWriter();
        if (Input.GetMouseButtonDown(0))
        {
            
            strindex++;//下一句
            isActive = true;
            if (strindex >= words.Length)//防止超出字串的長度
            {
                strindex = 0;
                
                Dia.SetActive(false);
            }
        }
    }

    public void StartEffect()
    {
        isActive = true;
    }
    /// 打字
    public  void OnStartWriter()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            {//判断計時器時間是否到達
                timer = 0;
                currentPos++;
                myText.text = words[strindex].Substring(0, currentPos);//刷新文本顯示内容

                if (currentPos >= words[strindex].Length)
                {
                    OnFinish();
                }
            }

        }
    }
    /// 結束打字，初始化數據
    public void OnFinish()
    {
        isActive = false;
        timer = 0;
        currentPos = 0;
        
    }
}
