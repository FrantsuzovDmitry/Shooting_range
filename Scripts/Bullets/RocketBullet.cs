using UnityEngine;

public class RocketBullet : Bullet
{
    [SerializeField] private float radius;
    [SerializeField] private float explodeForce;

    private void Explode()
    {
        //Получение коллайдеров в круге с центром в текущем положении объекта
        Collider2D[] overlappedColliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D collider in overlappedColliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                //Расстояние между центром взрыва и объектом
                Vector2 direction = collider.transform.position - transform.position;
                //Сила воздействия обратно ~ дальности от взрыва
                float forceImpact = explodeForce / (1 + direction.magnitude);  

                rb.AddForce(direction * forceImpact);
            }
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Explode();
        FixHit(collision);
    }

    protected override void Accept(IWeaponVisitor visitor) => visitor?.Visit(this, gameObject);
}
