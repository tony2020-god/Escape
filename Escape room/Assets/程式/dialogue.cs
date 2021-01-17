using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dialogue : MonoBehaviour
{
    public float charsPerSecond = 0.2f; //打字時間間隔
    public string[] words ; //保存需要顯示的文字
    public int strindex = 0; //控制語句
    public static dialogue instance; //對戰管理實體物件
    private bool isActive = false;
    private float timer = 0; //計時器
    public Text myText;
    public GameObject Dia;
    public int currentPos = 0; //當前打字位置
    public bool islongWriting = false;

    public void Awake()
    {
        instance = this;        
    }
    public void Start()
    {
        
        timer = 0;
        judgeRoom();
    }
    public void judgeRoom()
    {
        string name = SceneManager.GetActiveScene().name;
        if (name == "1F" || name == "2F" || name == "3F")
        {
            string[] wordstart = { "這裡是哪裡?", "我記得我昨天是躺在床上才對", "得先從這裡逃出去才行" };
            string[] wordsText = { "房間被上鎖了" };
            print(name);
            if(GameManager.StartGame == false)
            {
                words = wordstart;
                Dia.SetActive(true);
                Startdia();
                GameManager.instance.move = false;
            }
            else
            {
                words = wordsText;
            } 
        }
        if (name == "房間1F-1")
        {
            string[] wordsText = { "這裡有一個保險箱，密碼通常是9碼..." };
            words = wordsText;
            Dia.SetActive(true);
            StartEffect();
        }
        if (name == "房間1F-2")
        {
            string[] wordsText = { "得出左邊遺失的數字再跟著右邊走，左邊和15有關聯嗎?" };
            words = wordsText;
            Dia.SetActive(true);
            StartEffect();
        }
        if (name == "房間1F-3")
        {
            string[] wordsText = { "終於來到大廳了，只差一步就能逃出去了" };
            words = wordsText;
            Dia.SetActive(true);
            StartEffect();
        }
        if (name == "房間2F-1")
        {
            string[] wordsText = { "黑板上有些奇怪的數字，好像是簽名" };
            words = wordsText;
            Dia.SetActive(true);
            StartEffect();
        }
        if (name == "房間2F-2")
        {
            string[] wordsText = { "又有一個保險箱...","地上有不同顏色的油漆還有一個箭頭","好像是要遵循這個方向..." };
            words = wordsText;
            Dia.SetActive(true);
            StartEffect();
        }
        if (name == "房間2F-3")
        {
            string[] wordsText = { "好凌亂的房間，桌上還有一些廢紙" };
            words = wordsText;
            Dia.SetActive(true);
            StartEffect();
        }
        if (name == "房間2F-4")
        {
            string[] wordsText = { "這些破碎的窗戶好像有甚麼玄機" };
            words = wordsText;
            Dia.SetActive(true);
            StartEffect();
        }
        if (name == "房間3F-1")
        {
            string[] wordsText = { "這裡好暗，感覺甚麼都沒有..." };
            words = wordsText;
            Dia.SetActive(true);
            StartEffect();
        }
        if (name == "房間3F-2")
        {
            string[] wordsText = { "好像是音樂教室" };
            words = wordsText;
            Dia.SetActive(true);
            StartEffect();
        }
        if (name == "房間3F-3")
        {
            string[] wordsText = { "第三個保險箱...還有一門..." };
            words = wordsText;
            Dia.SetActive(true);
            StartEffect();
        }
    }
    public void Update()
    {
        OnStartWriter();
            if (Input.GetMouseButtonDown(0))
            {
                timer = 0;
                currentPos = 0;
                strindex++; //下一句
                isActive = true;
                if (strindex >= words.Length) //防止超出字串的長度
                {
                    strindex = 0;
                    GameManager.instance.move = true;
                    GameManager.StartGame = true;
                    judgeRoom();
                    Dia.SetActive(false);
                }
            }
       
    }

    public void StartEffect()
    {
        isActive = true;
    }
    public void Startdia()
    {
        timer = 0;
        currentPos = 0;
        strindex = 0; 
        isActive = true;
    }
    /// 打字
    public  void OnStartWriter()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            { //判断計時器時間是否到達
                timer = 0;
                currentPos++;
                myText.text = words[strindex].Substring(0, currentPos); //刷新文本顯示内容

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
