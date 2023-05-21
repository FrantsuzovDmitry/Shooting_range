using UnityEngine;

public class ShotgunBullet : Bullet
{
    protected override void Accept(IWeaponVisitor visitor) => visitor?.Visit(this, gameObject);
}
