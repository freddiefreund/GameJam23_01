using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer head;
        [SerializeField] private SpriteRenderer body;
        [SerializeField] private SpriteRenderer armFront;
        [SerializeField] private SpriteRenderer armBack;
        [SerializeField] private SpriteRenderer weapon;
        [SerializeField] private SpriteRenderer legs;
        
        private List<CharacterPart> _parts;

        public void AddPart(CharacterPart part)
        {
            if (part is CharacterHead)
            {
                head.sprite = part.sprite;
            }else if (part is CharacterBody)
            {
                body.sprite = part.sprite;
            }else if (part is CharacterArms)
            {
                armFront.sprite = part.sprite;
                armBack.sprite = ((CharacterArms)part).sprite2;
            }else if (part is CharacterWeapon)
            {
                weapon.sprite = part.sprite;
            }
        }
    }
}
