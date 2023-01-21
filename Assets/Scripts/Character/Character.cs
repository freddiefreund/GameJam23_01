using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Sprite head;
        [SerializeField] private Sprite body;
        [SerializeField] private Sprite armFront;
        [SerializeField] private Sprite armBack;
        [SerializeField] private Sprite weapon;
        [SerializeField] private Sprite legs;
        
        private List<CharacterPart> _parts;

        public void AddPart(CharacterPart part)
        {
            if (part is CharacterHead)
            {
                head = part.sprite;
            }else if (part is CharacterBody)
            {
                body = part.sprite;
            }else if (part is CharacterArms)
            {
                armFront = part.sprite;
                armBack = ((CharacterArms)part).sprite2;
            }else if (part is CharacterWeapon)
            {
                weapon = part.sprite;
            }
        }
    }
}
