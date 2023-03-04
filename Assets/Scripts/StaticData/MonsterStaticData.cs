using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "MonsterData", menuName = "Static Data/Monster")]
    public class MonsterStaticData : ScriptableObject
    {
        public MonsterTypeId MonsterTypeId;

        public int Hp = 50;
        public float Damage = 10;
        public float MoveSpeed;
        public float EffectiveDistance;

        public GameObject Prefab;
    }
}