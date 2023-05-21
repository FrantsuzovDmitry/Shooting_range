using UnityEngine;

public class Stand : MonoBehaviour, IWeaponVisitor
{
    [SerializeField] GameObject pistolVisualEffect;
    [SerializeField] GameObject shotgunVisualEffect;
    [SerializeField] GameObject rocketVisualEffect;

    private void ShowEffect(GameObject effect, Vector2 pos, float timeInSec)
    {
        var e = Instantiate(effect, pos, Quaternion.identity);
        Destroy(e, 0.5f);
    }

    public void Visit(PistolBullet bullet, GameObject obj)
    {
        ShowEffect(pistolVisualEffect, bullet.transform.position, 0.5f);
        Destroy(obj);
    }

    public void Visit(ShotgunBullet bullet, GameObject obj)
    {
        ShowEffect(shotgunVisualEffect, bullet.transform.position, 0.5f);
        gameObject.transform.Rotate(0, 0, 3);                                  //Подставка слегка накланяется
        Destroy(obj);
    }

    public void Visit(RocketBullet bullet, GameObject obj)
    {
        ShowEffect(rocketVisualEffect, bullet.transform.position, 1f);
        float currentRotation = gameObject.transform.rotation.z;
        gameObject.transform.Rotate(0, 0, 8 * (1 + 3*currentRotation));        //Чем сильнее подбит стенд, тем сильнее его разворачивает
        Destroy(obj);
    }
}
