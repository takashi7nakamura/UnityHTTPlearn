using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadingAnimator : MonoBehaviour
{
    public GameObject circleSpritePrefab;

    private GameObject circleSprite;

    private float elapsedTime;

    static string requrl = "http://kaitgamdev.sakura.ne.jp/00semi/samplephp/getid.php";

    // Start is called before the first frame update
    void Start()
    {
        // 経過時間を初期化
        elapsedTime = 0.0f;
 
        // CircleSprite を一つ生成
        circleSprite = Instantiate(circleSpritePrefab);

        // コルーチンを実行
        StartCoroutine("LoadingAnimationSequence");
        
    }

    // Update is called once per frame
    void Update()
    {
        // 経過時間を測定する
        elapsedTime += Time.deltaTime;       
    }

    IEnumerator LoadingAnimationSequence()
    {
        // コルーチンで実行される処理
        Debug.Log("Start Coroutine");

        // 最初の1秒で段々大きくなる
        while (elapsedTime < 1.0f)
        {
            circleSprite.GetComponent<CircleSprite>().SetMagnitude(elapsedTime * 1.0f);
            yield return null;
        }

        // HTTP Get Request を送ってレスポンスを得る
        UnityWebRequest www = UnityWebRequest.Get(requrl);
        yield return www.SendWebRequest();

        // エラーかどうかの判定
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        } else
        {
            // エラーでない場合は受け取ったテキストを取得
            Debug.Log(www.downloadHandler.text);
        }

        // 1秒待つ
        yield return new WaitForSeconds(1.0f);

        // 最後の1秒で段々小さくなる
        elapsedTime = 0.0f; // 経過時間をリセット
        while (elapsedTime < 1.0f)
        {
            circleSprite.GetComponent<CircleSprite>().SetMagnitude(1.0f - elapsedTime * 1.0f);
            yield return null;
        }

        Debug.Log("Done");
    }
}
