using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData", order = 1)]
    public class CardData : ScriptableObject
    {
        public string titleText;
        public Sprite cardImage;
        public Sprite backgroundImage;
        public string descriptionText;
        public CharacterPart characterPart;
        
    }
}
