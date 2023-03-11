using ScriptableObjects;
using UnityEngine;

namespace Character
{
    class Enemy : Character
    {
        [SerializeField] private EnemyData _enemyData;

        private void Start()
        {
            UpdateData(_enemyData);
        }

        public void UpdateData(EnemyData data)
        {
            HP = data.hp;
            AttackHead = data.attackHead;
            AttackBody = data.attackBody;
            HeadDefense = data.headDefense;
            BodyDefense = data.bodyDefense;
            Speed = data.speed;

            GetComponent<SpriteRenderer>().sprite = data.sprite;
        }
    }
}
