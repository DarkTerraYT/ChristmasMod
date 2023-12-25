using MelonLoader;
using UnityEngine;

namespace ChristmasMod
{
    [RegisterTypeInIl2Cpp]
    internal class RotateXYZ : MonoBehaviour
    {
        private static readonly Vector3 defaultSpeed = new(1, 1, 1);
        public float speed = 500;
        public void Update()
        {
            transform.Rotate(defaultSpeed * speed * Time.deltaTime);
        }
    }
}
