using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 2)]
    class EnemyData : ScriptableObject
    {
        public Sprite sprite;
        public AudioClip weaponSound;
        public float hp;
        public float attackHead;
        public float attackBody;
        public float headDefense;
        public float bodyDefense;
        public float speed;
    }
}
