using UnityEngine;

namespace Entity.Bullet
{
    public class BulletMover : MonoBehaviour
    {
        [SerializeField] private float _speed ;
        private float _bulletSpeed;

        private void Start()
        {
            _bulletSpeed = _speed;
        }

        private void Update()
        {
            transform.Translate(0,_bulletSpeed*Time.deltaTime ,0);
        }
    
        private void OnEnable()
        {
            _bulletSpeed = _speed;
        }

        private void OnDisable()
        {
            _bulletSpeed = 0;
        }
    }
}