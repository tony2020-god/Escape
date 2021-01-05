using UnityEngine;
using System.Collections.Generic;
using System.Collections;//引用系統集合、管理API(協同程式:非同步處理)
using UnityEngine.Animations;

public class BackGround : MonoBehaviour
{
    public Color white = Color.white;
    public Color gray = new Color(120, 120, 120);
    public void Update()
    {
        StartCoroutine(colorchange());
    }

    public IEnumerator colorchange()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(white,gray,20f* Time.deltaTime);
        yield return new WaitForSeconds(1.5f);
        GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(gray, white, 20f * Time.deltaTime);
        yield return new WaitForSeconds(1.5f);
    }
}
