namespace DungeonsAndCodeWizards.Models.Characters.Factory
{
    using System.Collections.Generic;
    public interface ICharacterFactory
    {
        Character CreateCharacter(string faction, string characterType, string name);

        string PickUpItem(string characterName, List<Item> pool, List<Character> characters);

        Character InstansedCharacter(List<Character> characters,string name);
        
    }
}
