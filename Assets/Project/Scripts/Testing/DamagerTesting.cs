
using UnityEngine;
using UnityEngine.InputSystem;

public class DamagerTesting : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    [SerializeField] private float damage;

    private void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 position = Mouse.current.position.ReadValue();
            Ray ray = camera.ScreenPointToRay(position);
            if(!Physics.Raycast(ray, out var hit))
                return;

            if(hit.rigidbody == null)
                return;

            IHealth health = hit.rigidbody.GetComponent<IHealth>();
            if(health != null)
                health.Damage(damage);

            IHittable hittable = hit.collider.GetComponent<IHittable>();
            if(hittable != null)
                hittable.Hit(new ShotHitData());
        }
    }
}