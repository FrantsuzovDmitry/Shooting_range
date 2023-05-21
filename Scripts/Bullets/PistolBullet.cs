using UnityEngine;

public class PistolBullet : Bullet
{
    protected override void Accept(IWeaponVisitor visitor) => visitor?.Visit(this, gameObject);
}
