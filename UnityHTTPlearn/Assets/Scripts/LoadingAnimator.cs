using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingAnimator : MonoBehaviour
{
    public GameObject circleSpritePrefab;

    private GameObject circleSprite;

    private float elapsedTime;

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
        // 3秒待つ
        yield return new WaitForSeconds(3);

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
