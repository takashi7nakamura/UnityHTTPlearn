using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 位置座標
    private Vector3 mousePosition;

    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldMousePosition;

    // 速度(定数)
    static public float moveVelocity = 4.0f;

    // 移動範囲
    static float minX = -7.0f;
    static float maxX = 7.0f;
    static float minY = -4.4f;
    static float maxY = 4.4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // マウスの位置座標を取得する
        mousePosition = Input.mousePosition;

        // Z軸補正
        mousePosition.z = 10.0f;

        // マウス位置座標をスクリーン座標からワールド座標に変換する
        screenToWorldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // マウス位置座標から現在位置の距離に応じて速度を与える
        // 速度ベクトル = マウス座標 - 現在位置
        // 速度ベクトルを正規化
        // 速度ベクトルに定数をかける(これを速度とする)
        Vector3 v = screenToWorldMousePosition - transform.position;
        Vector3 nv = v.normalized;

        // 速度から次の位置を計算してセットする
        // 新しい位置 = 現在位置 + 速度ベクトル* 経過時間
        Vector3 newpos = transform.position + nv * Time.deltaTime * moveVelocity;

        // 移動範囲を制限する
        newpos.x = Mathf.Clamp(newpos.x, minX, maxX);
        newpos.y = Mathf.Clamp(newpos.y, minY, maxY);

        // ワールド座標に変換されたマウス座標を代入する
        transform.position = newpos;

    }

    // 当たり判定の処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 当たったオブジェクトがコインなら
        if (collision.gameObject.tag == "Coin")
        {
            // 当たったコインを消す
            collision.gameObject.SetActive(false);
        }


        // 当たったオブジェクトが障害物なら
        if (collision.gameObject.tag == "Obstacle")
        {
            // 自分を非表示にする
            gameObject.SetActive(false);
        }
    }
}
