using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Chara
{
	public GameObject enemyObject;
	private GameObject targetObject;    //ターゲット

	private int Enemylife;
	private float Enemyspeed;     //敵速度
	private int Attack_damege;    //攻撃力
	private float HitPower;     //ヒット時の力

	private Vector3 targetPos;     //LookAt調整用
	private bool AttackSwitch;        //アタック呼び出し

	private int count;
	Rigidbody rigidBody;

	public enum EnemyType     //エネミー種類 
	{
		Normal,              //通常型
		Powerful,            //高威力型
		Quick                //高速型
	};
	public EnemyType enemyType;

	public Enemy()
	{
	}

	void Start()
	{
		targetObject = GameObject.FindGameObjectWithTag("Player");//プレイヤ検索

		rigidBody = GetComponent<Rigidbody>();

		this.charaParam = new Param(0.0f, Enemylife, 0, Enemyspeed, Param.Status.Move);
		//-----------------------------------------------------------------------------
		//エネミータイプ変更
		switch (this.enemyType)
		{
			case EnemyType.Normal:
				Debug.Log("通常型");

				Enemylife = enemyObject.GetComponent<Enemy_Normal>().enemyHP();
				Enemyspeed = enemyObject.GetComponent<Enemy_Normal>().moveSpeed();
				Attack_damege = enemyObject.GetComponent<Enemy_Normal>().damege();
				HitPower = enemyObject.GetComponent<Enemy_Normal>().knockback();

				break;

			case EnemyType.Powerful:
				Debug.Log("高威力型");

				Enemylife = enemyObject.GetComponent<Enemy_Powerful>().enemyHP();
				Enemyspeed = enemyObject.GetComponent<Enemy_Powerful>().moveSpeed();
				Attack_damege = enemyObject.GetComponent<Enemy_Powerful>().damege();
				HitPower = enemyObject.GetComponent<Enemy_Powerful>().knockback();

				break;

			case EnemyType.Quick:
				Debug.Log("高速型");

				Enemylife = enemyObject.GetComponent<Enemy_Quick>().enemyHP();
				Enemyspeed = enemyObject.GetComponent<Enemy_Quick>().moveSpeed();
				Attack_damege = enemyObject.GetComponent<Enemy_Quick>().damege();
				HitPower = enemyObject.GetComponent<Enemy_Quick>().knockback();

				break;
		}

	}

	void Update()
	{
		EnemyLook();

			Move();
		
		
		Debug.Log("スピード" + Enemyspeed);
	}

	public override void Attack()
	{
		//攻撃
	}
	public override void Hit(int damage_)
	{
        //当たり判定の後の処理
        Enemylife -= damage_;
        Destroy();
        Debug.Log("ライフ" + Enemylife);
	}
	public override void Move()
	{
		//動き
		switch (this.charaParam.status)
		{
			case Param.Status.Waiting:   //待機中の処理

				WaitingUpdate();
				break;
			case Param.Status.Attack: //攻撃中の処理
				AttackUpdate();
				break;
			case Param.Status.Move:   //動いている間の処理
				MoveUpdate();
				break;
			case Param.Status.Hit:    //被弾中の処理
				HitUpdate();
				break;
		}
	}
	public override void Anim()
	{
		//アニメーション
		switch (this.charaParam.status)
		{
			case Param.Status.Waiting:   //待機中のアニメーション
				WaitingAnim();
				break;
			case Param.Status.Attack: //攻撃中のアニメーション
				AttackAnim();
				break;
			case Param.Status.Move:   //動いている間のアニメーション
				MoveAnim();
				break;
			case Param.Status.Hit:    //被弾中のアニメーション
				HitAnim();
				break;
		}
	}
	public override void WaitingUpdate()
	{
		
		//待機中の処理
	}
	public override void AttackUpdate()
	{
		//攻撃中の処理
	}
	public override void MoveUpdate()
	{

	
			transform.position = Vector3.MoveTowards(transform.position, targetPos, Enemyspeed);
			//動いている間の処理
		
	}
	public override void HitUpdate()
	{
		//被弾中の処理
	}

	public override void WaitingAnim()
	{
		//待機中のアニメーション
	}
	public override void AttackAnim()
	{
		//攻撃中のアニメーション
	}
	public override void MoveAnim()
	{
		//動いている間のアニメーション
	}
	public override void HitAnim()
	{
		//被弾中のアニメーション

	}
	void EnemyLook()
	{
		//向き調整
		targetPos = targetObject.transform.position;
		targetPos.y = transform.position.y;
		transform.LookAt(targetPos);
	}
	void Destroy()
    {
		if (Enemylife <= 0)
		{
			Destroy(this.gameObject);
		}
    }

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")//ヒット当たり判定　（仮で確認用にプレイヤtag（台座）に反応させてます後日変更します）
		{
			this.charaParam = new Param(0.0f, Enemylife, 0, Enemyspeed, Param.Status.Attack);
		}
		if (col.gameObject.tag == "Bullet")     //弾との当たり判定追加
		{

		}

	}
}