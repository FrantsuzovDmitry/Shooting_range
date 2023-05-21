using UnityEngine;

public class Balloon : MonoBehaviour, IWeaponVisitor
{
    private void DestroyItself() => Destroy(gameObject);

    public void Visit(PistolBullet bullet, GameObject obj)
    {
        DestroyItself();
    }

    public void Visit(ShotgunBullet bullet, GameObject obj)
    {
        DestroyItself();
    }

    public void Visit(RocketBullet bullet, GameObject obj)
    {
        DestroyItself();
    }
}
