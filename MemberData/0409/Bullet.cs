using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public enum BulletType
{
    Normal,     //通常弾
    Pierce,     //貫通弾
    Explosive,  //爆発弾
}

public class Bullet : MonoBehaviour
{
    BulletType bulletType;  //種類
    public int bPower; //威力
    public float bSpeed;    //スピード
    public new MeshRenderer renderer;

    public Bullet(BulletType bulletType_)
    {
        this.bulletType = bulletType_;

        switch(this.bulletType)
        {
            case BulletType.Normal:
                {
                    this.bPower = 1;
                    this.bSpeed = 20.0f;
                    break;
                }
            case BulletType.Pierce:
                {
                    this.bPower = 1;
                    this.bSpeed = 20.0f;
                    break;
                }
            case BulletType.Explosive:
                {
                    this.bPower = 1;
                    this.bSpeed = 20.0f;
                    break;
                }
        }
    }

	public virtual void Start()
	{
        renderer = GetComponentInChildren<MeshRenderer>();
    }
	public virtual void Update()
	{
        Shoot(this.bSpeed);
        if(!renderer.isVisible)
		{
            Destroy(gameObject);
		}
    }
    public void Shoot(float bSpeed_)
	{
        this.transform.position += transform.forward * bSpeed_ * Time.deltaTime;
    }

    public int GetPower() 
    {
        return bPower;
    }
}
