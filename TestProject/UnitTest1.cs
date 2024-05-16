using DiplomAttempt2.ViewModels;
using DiplomAttempt2.Models;


namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void CharacterViewModelAbilitiesTest()
        {
            Character mockChar = new Character()
            {
                Abilities = new Dictionary<Ability, int>()
                {
                    {Ability.Strength, 8},
                    {Ability.Dexterity, 10},
                    {Ability.Constitution, 12},
                    {Ability.Wisdom, 14},
                    {Ability.Intelligence, 16},
                    {Ability.Charisma, 18},
                }
            };
            CharacterViewModel cvm = new CharacterViewModel(mockChar);
            Assert.Equal(-1, cvm.StrBonus);
            Assert.Equal(0, cvm.DexBonus);
            Assert.Equal(1, cvm.ConBonus);
            Assert.Equal(2, cvm.WisBonus);
            Assert.Equal(3, cvm.IntBonus);
            Assert.Equal(4, cvm.ChaBonus);
        }
        [Fact]
        public void CharacterViewModelHitsTest()
        {
            var invoked = false;

            Character mockChar = new Character()
            {
                Hits = 10,
                MaxHits = 10
            };
            CharacterViewModel cvm = new CharacterViewModel(mockChar);
            cvm.Character.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals("Hits"))
                    invoked = true;
            };
            cvm.Character.Hits--;

            Assert.True(invoked);
        }
    }
}