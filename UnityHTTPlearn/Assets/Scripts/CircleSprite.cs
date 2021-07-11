using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSprite : MonoBehaviour
{
    private float elapsedTime; // オブジェクトが生成されてからの経過時間(sec)
    static float period = 0.5f; // アニメーションの周期 (sec)
    static float maxAmplitude = 3.0f; // 振幅 

    private float radius; // 半径

    private float magnitude; // 倍率

    // Start is called before the first frame update
    void Start()
    {
        // 経過時間を初期化
        elapsedTime = 0.0f;

        // 初期の倍率
        magnitude = 0.0f;

        // 半径
        radius = maxAmplitude * magnitude; 
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

    // 倍率のパラメータをセットする
    // mag = 0.0 ～ 1.0 で指定する
    public void SetMagnitude(float mag)
    {
        magnitude = mag;

        radius = maxAmplitude * magnitude;
    }
}
