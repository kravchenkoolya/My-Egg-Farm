using FallingObjectLogic;
using TMPro;
using UnityEngine;

namespace PlayerComponents
{
    public class Buscket : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private TextMeshProUGUI _eggCountText;
        [SerializeField] private AudioClip _beepAudio;
        [SerializeField] private AudioSource _audioSource;
        private short _eggCount = 0;
        public short EggCount =>_eggCount;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out FallingObject fallingObject))
            {
                
                if (fallingObject.gameObject.CompareTag("Stone"))
                {
                    _player.GetDamage(fallingObject.Damage);
                    if (_eggCount - fallingObject.PointCountForBasket >= 0)
                    {
                        _eggCount -= fallingObject.PointCountForBasket;
                    }
                }
                else if (fallingObject.gameObject.CompareTag("Egg"))
                {
                    _eggCount += fallingObject.PointCountForBasket;
                    if (Data.SoundEffect)
                    {
                        _audioSource.PlayOneShot(_beepAudio, 1);
                    }
                }
                Destroy(col.gameObject);
                UpdateEggCountText();
            }
      
        }
        
        private void UpdateEggCountText() => _eggCountText.text = _eggCount.ToString();
    }
}