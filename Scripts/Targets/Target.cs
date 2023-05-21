using UnityEngine;

public class Target : MovableTarget, IWeaponVisitor
{
    [SerializeField] GameObject pistolVisualEffect;
    [SerializeField] GameObject shotgunVisualEffect;
    [SerializeField] GameObject rocketVisualEffect;

    private void MoveAndShowEffect(GameObject effect, Vector2 pos, Bullet bullet, float force, float timeInSec)
    {
        var e = Instantiate(effect, pos, Quaternion.identity);
        MoveItem(bullet.DirectionOfTargetMove, force);
        Destroy(e, timeInSec);      //Удаление эффекта со сцены через некоторое время
    }

    public void Visit(PistolBullet bullet, GameObject obj)
    {
        MoveAndShowEffect(pistolVisualEffect, bullet.transform.position, bullet, bullet.ShotForce, 0.5f);
        Destroy(obj);
    }

    public void Visit(ShotgunBullet bullet, GameObject obj)
    {
        MoveAndShowEffect(shotgunVisualEffect, bullet.transform.position, bullet, bullet.ShotForce, 0.5f);
        Destroy(obj);
    }

    public void Visit(RocketBullet bullet, GameObject obj)
    {
        MoveAndShowEffect(rocketVisualEffect, bullet.transform.position, bullet, bullet.ShotForce, 1f);
        Destroy(obj);
    }
}
