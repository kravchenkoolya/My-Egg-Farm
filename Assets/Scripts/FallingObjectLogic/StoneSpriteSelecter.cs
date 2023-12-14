using UnityEngine;
using Random = UnityEngine.Random;

namespace FallingObjectLogic
{
    public class StoneSpriteSelecter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite[] _spritesStone;
        private void Awake() => _spriteRenderer.sprite = _spritesStone[Random.Range(0, _spritesStone.Length)];
    }
}