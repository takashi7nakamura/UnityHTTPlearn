using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSprite : MonoBehaviour
{
    private float elapsedTime; // オブジェクトが生成されてからの経過時間(sec)
    static float period = 0.5f; // アニメーションの周期 (sec)
    static float maxAmplitude = 3.0f; // 振幅 

    private float radius; // 半径

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0.0f;
        radius = maxAmplitude; 
    }

    // Update is called once per frame
    void Update()
    {
        // 経過時間を計算する
        elapsedTime += Time.deltaTime;

        // 現在の角度をラジアンで求める
        float rad = elapsedTime / period * 2 * Mathf.PI; 

        Vector3 cpos = new Vector3( Mathf.Sin(rad) * radius, Mathf.Cos(rad) * radius, 1.0f );
        transform.position = cpos;

    }
}
