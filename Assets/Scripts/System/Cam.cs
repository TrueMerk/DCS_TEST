using UnityEngine;

namespace System
{
    public class Cam : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        private Vector3 _offset;

        private void Start()
        {
            var transformPosition = transform.position;
            _offset = _target.transform.position - transformPosition;
        }

        private void Update()
        {
            var desiredAngle = _target.transform.eulerAngles.y;
            var rotation = Quaternion.Euler(0, desiredAngle, 0);
            transform.position = _target.transform.position -(rotation * _offset);
            transform.LookAt(_target.transform);
        }
    }
}
