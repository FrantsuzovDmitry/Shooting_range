using UnityEngine;

public abstract class MovableTarget : MonoBehaviour
{
    [SerializeField] Rigidbody2D target;
    virtual public void MoveItem(Vector2 direction, float force)
    {
        target.AddForce(direction.normalized * force, ForceMode2D.Impulse);
    }
}
