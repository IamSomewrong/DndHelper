using DiplomAttempt2.Models;

namespace DiplomAttempt2
{
    public interface ICharacterPage
    {
        public Character character { get; set; }
        public void Initialize();
    }
}
