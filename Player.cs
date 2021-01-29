using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]// SerializeFieldと書くとその次の変数がエディタ上で数値を調整可能になる
	private float JumpPower = 400;// ジャンプ力

	[SerializeField]
	private float MoveSpeed = 10;// 移動スピード

	private bool Grounded;// 地面についているか判定する変数

	private Rigidbody rb;// Rigidbodyを扱うための変数

	public float sensitivityX = 15F;//マウスの横の動きの強さ
	public float sensitivityY = 15F;//マウスの縦の動きの強さ

	public float minimumX = -360F;//横の回転の最低値
	public float maximumX = 360F;//横の回転の最大値

	public float minimumY = -60F;//縦の回転の最低値
	public float maximumY = 60F;//縦の回転の最大値

	public GameObject mainCamera;
	Camera cameraClass;

	float rotationX;

	void Start()
	{
		rb = GetComponent<Rigidbody>();// Rigidbodyの値を取得してrbに代入する
		cameraClass = mainCamera.GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.W))// もし、Wキーがおされたら、
		{
			 transform.position += transform.TransformDirection(Vector3.forward * MoveSpeed * Time.deltaTime);// 前方に進む
		}

		if (Input.GetKey(KeyCode.S))// もし、Sキーがおされたら、
		{
			transform.position += transform.TransformDirection(Vector3.back * MoveSpeed * Time.deltaTime);// 後方に進む
		}
	    if (Input.GetKey(KeyCode.A))// もし、Aキーがおされたら、
        {
            transform.position += transform.TransformDirection(Vector3.left * MoveSpeed * Time.deltaTime);// 左に進む
        }
        if (Input.GetKey(KeyCode.D))// もし、Dキーがおされたら、
        {
            transform.position += transform.TransformDirection(Vector3.right * MoveSpeed * Time.deltaTime);// 右に進む
        }

		if (Grounded == true)//  もし、Groundedがtrueなら、
		{
			if (Input.GetKeyDown(KeyCode.Space))//  もし、スペースキーがおされたなら、  
			{
				Grounded = false;//  Groundedをfalseにする
				rb.AddForce(Vector3.up * JumpPower);//  上にJumpPower分力をかける
			}
		}
		if(transform.position.y < -30){//落下したら
			transform.position = new Vector3(0,20,0);
			rb.velocity = Vector3.zero;
		}

		/*ここから本題*/
		// //public変数
		rotationX = cameraClass.rotationX;
		//プロパティ
		// rotationX = cameraClass.getrotationX;
		// //関数
		// rotationX = cameraClass.retrotationX();

		Debug.Log(rotationX);//変数が受け取れているか確認
		transform.localEulerAngles = new Vector3(0,rotationX,0);//Playerの向きを設定する。
	}

	void OnCollisionEnter(Collision other)//  地面に触れた時の処理
	{
		if (other.gameObject.tag == "Ground")//  もしGroundというタグがついたオブジェクトに触れたら、
		{
			Grounded = true;//  Groundedをtrueにする
		}
	}
}