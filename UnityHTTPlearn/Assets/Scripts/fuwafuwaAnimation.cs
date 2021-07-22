using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuwafuwaAnimation : MonoBehaviour
{
    private float elapsedTime; // 経過時間
    static float period = 1.5f; // アニメーションの周期 (sec)
    static float radius = 6.0f; // 動く半径

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0.0f;    
    }

    // Update is called once per frame
    void Update()
    {
        // 経過時間の計算
        elapsedTime += Time.deltaTime;
        float rad = elapsedTime * 2.0f * Mathf.PI/period;
        Vector2 pos = new Vector2(radius * Mathf.Sin(rad), radius * Mathf.Cos(rad));
        // 位置情報の更新
        GetComponent<RectTransform>().anchoredPosition = pos;
    }
}
