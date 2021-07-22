using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject obstacleManager;
    public GameObject coinManager;

    public GameObject player;

    public GameObject clickStartText;
    public GameObject scoreText;

    private int gameScore; //ゲームのスコア


    public enum GAME_STATE
    {
        GAME_TITLE,  // タイトル画面
        GAME_GAME,   // ゲーム画面
        GAME_RESULT, // リザルト画面
    }

    private GAME_STATE state;

    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        InitTitleState();
    }

    // Update is called once per frame
    void Update()
    {
        // 経過時間の計算
        elapsedTime += Time.deltaTime;

        // ゲームの状態によっての処理変更
        switch (state)
        {
            case GAME_STATE.GAME_TITLE: // タイトル表示状態
                // マウスボタンが押されたら
                if (Input.GetMouseButtonDown(0))
                {
                    // ゲーム開始状態へ
                    InitGameState();
                }
                break;
            case GAME_STATE.GAME_GAME: // ゲームプレイ中
                if (player.activeSelf == false)
                {
                    InitResultState();
                }
                break;
            case GAME_STATE.GAME_RESULT: // リザルト表示中
                if (Input.GetMouseButtonDown(0))
                {
                    // ゲームステートへ
                    InitGameState();
                }
                break;
            default:
                break;
        }

    }

    // スコアが加算された時の処理
    public void AddScore(int add)
    {
        // ゲームのスコア加算時
        gameScore += add;

        // スコア表示のテキストを更新する
        scoreText.GetComponent<Text>().text = gameScore.ToString();
    }

    // タイトル状態に入った時の初期化処理
    private void InitTitleState()
    {
        state = GAME_STATE.GAME_TITLE;

        InitGameObjects();
        // Click to Start表示をONにする
        clickStartText.SetActive(true);

        // Playerの表示はOFFにする
        player.SetActive(false);
        
    }

    // ゲーム状態に入った時の初期化処理
    private void InitGameState()
    {
        // Click to Start 表示をOFFにする
        clickStartText.SetActive(false);

        state = GAME_STATE.GAME_GAME;

        // Playerの位置は初期位置(0,0)に設定する
        player.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        // Player位置の表示を開始する
        player.SetActive(true);

        // スコアは0点にする
        gameScore = 0;

        InitGameObjects();
    }

    // リザルト状態に入った時の初期化処理
    private void InitResultState()
    {
        state = GAME_STATE.GAME_RESULT;
    }

    private void InitGameObjects()
    {
        obstacleManager.GetComponent<ObstacleManager>().DestroyAll();
        coinManager.GetComponent<CoinManager>().DestroyAll();

    }

}
