using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;//引用系統集合、管理API(協同程式:非同步處理)
public class Player : MonoBehaviour
{
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10.5f;
    public Animator ani;
    public AudioSource aud;
    public Rigidbody2D rig;
    public bool indoor;
    public bool floorup1;
    public bool floorup2;
    public bool floordown2;
    public bool floordown3;

 
    public void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    public void Update()
    {
        Move();
        StartCoroutine(INSIDE());
    }
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        //水平浮點數 = 輸入 的 取得軸向("水平")-左右AD
        float h = Input.GetAxis("Horizontal");
        //剛體 的 加速度 = 新 二維向量(水平浮點數 * 速度, 剛體的加速度Y)
        rig.velocity = new Vector2(h * speed, rig.velocity.y);
        //動畫的設定布林值(參數名稱，水平 不等於零時勾選)
        ani.SetBool("跑步開關", h != 0);
        //keycode 列單(下拉式選單) 所有輸入的選項:滑鼠、鍵盤、搖桿
        if (Input.GetKeyDown(KeyCode.D))
        {
            //此物件的變形元件
            //eulerAngles 歐拉角度
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }
    public void Dead(string obj)
    {
        if (obj == "敵人")
        {
            if (ani.GetBool("死亡觸發")) return;
            enabled = false;
            ani.SetBool("死亡觸發", true);
        }
    }
    private void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    /// <summary>
    /// ODE碰撞時執行一次的事件
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Dead(collision.gameObject.tag);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "房間") indoor = true;
        if (collision.tag == "1F上樓區域") floorup1 = true;
        if (collision.tag == "2F上樓區域") floorup2 = true;
        if (collision.tag == "2F下樓區域") floordown2 = true;
        if (collision.tag == "3F下樓區域") floordown3 = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "房間") indoor = false;
        if (collision.tag == "1F上樓區域") floorup1 = false;
        if (collision.tag == "2F上樓區域") floorup2 = false;
        if (collision.tag == "2F下樓區域") floordown2 = false;
        if (collision.tag == "3F下樓區域") floordown3 = false;
    }
    private IEnumerator INSIDE()
    {
        //門
        if (indoor && Input.GetKeyDown(KeyCode.W)) //如果 在門裡面 並且按下w
        {
            int lvindex = SceneManager.GetActiveScene().buildIndex;  //取得當前的場景編號
            lvindex++;                                               //編號加一
            SceneManager.LoadScene(lvindex);                         //載入下一個
        }
        //1F上2F
        if (floorup1 && Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(GameManager.instance.Endloadingimage());
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("2F");
        }
        //2F上3F
        if (floorup2 && Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(GameManager.instance.Endloadingimage());
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("3F");
        }
        //2F下1F
        if (floordown2 && Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(GameManager.instance.Endloadingimage());
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("1F");
        }
        //3F下2F
        if (floordown3 && Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(GameManager.instance.Endloadingimage());
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("2F");
        }
    }
}