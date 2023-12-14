using System;
using UI;
using UnityEngine;

namespace FallingObjectLogic
{
    public class FallingObject : IPauseObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private byte _damage;
        [SerializeField] private byte _pointCountForBasket;
        private PauseController _pauseController;
        public byte PointCountForBasket => _pointCountForBasket;
        public byte Damage => _damage;
        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(transform.position.x, -5000, transform.position.z), _speed * Time.deltaTime);
        }

        public override void Pause() => enabled = false;

        public override void Play() => enabled = true;

        private void OnDestroy() => _pauseController.PauseObjects.Remove(this);

        public void Initial(PauseController pauseController)
        {
            _pauseController = pauseController;
            _pauseController.PauseObjects.Add(this);
        }
    }
    
}