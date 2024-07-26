using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PanelContlloler : MonoBehaviour
{
    [SerializeField]
    fruits hurutu;
    [SerializeField]
    Dropper dropper;
    [SerializeField]
    float rotation;
    [SerializeField]
    Score score;
    //リザルト画面かどうか
    bool result = false;
    //今ボタンが押されているかどうか
    bool buttonPressed;
    // micro:bitのボタンの状態(0: なし、1: Aボタン、-1: Bボタン)
    private int buttonState = 0;
    // micro:bitの傾き(x軸方向の加速度計の値)
    private float tilt = 0;

    public void Start()
    {
    }

    void Update()
    {
        if (result ==false)
        {
            if (buttonState == 1 && !buttonPressed)
            {
                buttonPressed = true;
                print("a_button");
                hurutu.fall();
                //ここにPopとPulsScoreを書く
                dropper.Pop();
                score.PulsScore();
            }
            if (buttonState == -1 && !buttonPressed)
            {
                buttonPressed = true;
                print("b_button");
                hurutu.fall();
                //ここにPopとPulsScoreを書く
                dropper.Pop();
                score.PulsScore();
            }
            if (buttonState == 0)
            {
                buttonPressed = false;
            }
            //この行の下に傾きのプログラムを書いてね
            rotation = tilt * 30f;
            if (-60f>rotation)
            {
                rotation = -60;
            }
            if (60f < rotation) 
            {
                rotation = 60;
            }
           transform.rotation = Quaternion.Euler(0,0,rotation);
        }
    }

    // micro:bitの加速度計のx軸方向の値を受け取ります
    public void OnAccelerometerChanged(int x)
    {
        const float MAX_X = 1600F;
        tilt = Mathf.Clamp(x / MAX_X, -1, 1);
    }

    // micro:bitのAボタンの通知を受け取ります
    public void OnButtonAChanged(int state)
    {
        buttonState = (state == 0 ? 0 : 1);
    }

    // micro:bitのBボタンの通知を受け取ります
    public void OnButtonBChanged(int state)
    {
        buttonState = (state == 0 ? 0 : -1);
    }
    public void set(fruits newhurutu)
    {
        hurutu = newhurutu;
    }

    // micro:bitとの接続が切れた場合に呼び出されます
    public void OnDisconnected()
    {
        Debug.Log("OnDisconnected");
    }

    public void Result()
    {
        result = true;
    }
}