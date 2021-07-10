using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // コルーチンを実行
        StartCoroutine("LoadingAnimationSequence");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadingAnimationSequence()
    {
        // コルーチンで実行される処理
        Debug.Log("Start Coroutine");

        yield return new WaitForSeconds(3);

        Debug.Log("Done");
    }
}
