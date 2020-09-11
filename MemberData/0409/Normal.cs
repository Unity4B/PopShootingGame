using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal : Bullet
{
    public Normal() : base(BulletType.Normal) { }

    public override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("通常ダメージ！");
            target.gameObject.GetComponent<Enemy>().Hit(bPower);
        }
    }
}
