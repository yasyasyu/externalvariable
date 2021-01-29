using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float sensitivityX = 15F;//マウスの横の動きの強さ
    public float sensitivityY = 15F;//マウスの縦の動きの強さ

    public float minimumX = -360F;//横の回転の最低値
    public float maximumX = 360F;//横の回転の最大値

    public float minimumY = -60F;//縦の回転の最低値
    public float maximumY = 60F;//縦の回転の最大値

    public float rotationX = 0f;        /*今回の要*/
    float rotationY = 0f;

    public GameObject Player;   //PlayerObject

    //関数
    public float retrotationX(){
        return rotationX;
    }
    //プロパティ
    public float getrotationX{
        get{ return this.rotationX; }
    }
    void Start()
    {
    }

    void Update()
    {
        transform.position = Player.transform.position;//座標をプレイヤー依存にする


        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;//rotationXを現在のyの向きにXの移動量*sensitivityXの分だけ回転させる
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;//rotationYにYの移動量*sensitivityYの分だけ増やす
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);//rotationYを-60〜60の値にする

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);//オブジェクトの向きをnew Vector3(-rotationY, rotationX, 0)にする
    }
}