using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject gm; // ゲームマネージャ

    // 位置座標
    private Vector3 mousePosition;

    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldMousePosition;

    // 速度(定数)
    static public float moveVelocity = 4.0f;

    // デフォルトのスケール(拡大率)
    static float magScale = 5.0f;

    // 移動範囲
    static float minX = -7.0f;
    static float maxX = 7.0f;
    static float minY = -4.4f;
    static float maxY = 4.4f;

    // 経過時間
    float elapsedTime;

    // 死んだ状態かのフラグ
    bool isDead;

    // 効果音関連
    public AudioClip seCoin; //コイン取得時の音
    public AudioClip seDead; //死んだ時の音

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0.0f;
        // 死んだかどうかのフラグ
        isDead = false;

        // AudioSourceのコンポーネントを取得する
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 経過時間を測定する
        elapsedTime += Time.deltaTime;

        // 死んでない時のみ移動の処理をする
        if (isDead == false)
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

    }

    // 当たり判定の処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 当たったオブジェクトがコインなら
        if (collision.gameObject.tag == "Coin")
        {
            // 当たったコインを消す
            collision.gameObject.SetActive(false);
            // スコアを加算する
            gm.GetComponent<GameManager>().AddScore(1);
            // コイン取得時の効果音を鳴らす
            audioSource.PlayOneShot(seCoin);
        }


        // 当たったオブジェクトが障害物なら
        if (collision.gameObject.tag == "Obstacle")
        {
            // 当たり判定を殺す
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            // アニメーション用のコルーチンを開始する
            StartCoroutine("DeadAnimation");
        }
    }

    // 表示パラメータ等をリセットする
    public void Reset()
    {
        // 回転をリセットする
        transform.rotation = Quaternion.identity;

        transform.localScale = new Vector3(magScale, magScale, 1.0f);
        isDead = false; // 生き返ります
        // 当たり判定を復活させます
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }

    // 死んだ時のアニメーション
    IEnumerator DeadAnimation()
    {
        elapsedTime = 0.0f; // 経過時間を初期化
        isDead = true; // 死んでます
        //死んだ時のジングルを鳴らす
        audioSource.PlayOneShot(seDead);

        while (elapsedTime < 0.8f)
        {
            // くるくる回るアニメーション
            transform.Rotate(0, 0, 1.0f);
            transform.localScale = new Vector3((1.0f - elapsedTime) * 5.0f, (1.0f - elapsedTime) * 5.0f,1.0f);
            yield return null;
        }

        // 自分を非表示にする
        gameObject.SetActive(false);
        yield return null;
    }
}
