using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Player : Character
    {
        [SerializeField] private SpriteRenderer head;
        [SerializeField] private SpriteRenderer body;
        [SerializeField] private SpriteRenderer armFront;
        [SerializeField] private SpriteRenderer armBack;
        [SerializeField] private SpriteRenderer weapon;
        [SerializeField] private SpriteRenderer legs;

        private List<CharacterPart> _parts = new List<CharacterPart>();

        private void Start()
        {
            DontDestroyOnLoad(this);
        }

        public void AddPart(CharacterPart part)
        {
            _parts.Add(part);

            if (part is CharacterHead)
            {
                head.sprite = part.sprite;
                HP += ((CharacterHead)part).hp;
                HeadDefense += ((CharacterHead)part).headDefense;
            }
            else if (part is CharacterBody)
            {
                body.sprite = part.sprite;
                HP += ((CharacterBody)part).hp;
                BodyDefense += ((CharacterBody)part).bodyDefense;
            }
            else if (part is CharacterArms)
            {
                armFront.sprite = part.sprite;
                armBack.sprite = ((CharacterArms)part).sprite2;
                UpdateDamageAndSpeed();
            }
            else if (part is CharacterWeapon)
            {
                weapon.sprite = part.sprite;
                WeaponSound = ((CharacterWeapon)part).audioClip;
                UpdateDamageAndSpeed();
            }
        }

        private void UpdateDamageAndSpeed()
        {
            CharacterArms arms = (CharacterArms)_parts.Find(part => part is CharacterArms);
            CharacterWeapon weapon = (CharacterWeapon)_parts.Find(part => part is CharacterWeapon);


            float attackBonus = arms.attackBonus;

            if (weapon != null)
            {
                AttackHead = weapon.attackValueHead * attackBonus;
                AttackBody = weapon.attackValueBody * attackBonus;
                Speed = arms.speedModifier * weapon.speedModifier;
            }
            else
            {
                AttackHead = 10 * attackBonus;
                AttackBody = 10 * attackBonus;
                Speed = arms.speedModifier;
            }
        }
    }
}
