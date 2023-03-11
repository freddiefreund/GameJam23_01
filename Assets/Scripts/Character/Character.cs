using System;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Character : MonoBehaviour
    {   
        public AudioClip WeaponSound { get; set; }
        public float HP { get; set; } = 100;
        public float AttackHead { get; set; }
        public float AttackBody { get; set; }
        public float HeadDefense { get; set; } = 1;
        public float BodyDefense { get; set; } = 1;
        public float Speed { get; set; } = 1;
    }
}
