using FallingObjectLogic;
using PlayerComponents;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private Player _player;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (TryGetComponent(out FallingObject fallingObject))
             {
                 if (fallingObject.gameObject.CompareTag("Egg"))
                {
                 _player.GetDamage(fallingObject.Damage);
                Debug.Log("minus h");
                }   
            }
        Destroy(col.gameObject);
    }
}