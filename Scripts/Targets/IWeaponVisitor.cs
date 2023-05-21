using UnityEngine;

public interface IWeaponVisitor
{
    public void Visit(PistolBullet bullet, GameObject obj);
    public void Visit(ShotgunBullet bullet, GameObject obj);
    public void Visit(RocketBullet bullet, GameObject obj);
}
