using System.Collections;
using System.Linq;

namespace CharacterCopy.CopyKata
{
    public class Copier
    {
        private readonly ISource _source;
        private readonly IDestination _destination;
        private char newLine = '\n';

        public Copier(ISource source, IDestination destination)
        {
            _source = source;
            _destination = destination;
        }

        public void Copy()
        {
            var character = _source.ReadChar();

            if (!character.Equals(newLine))
            {
                _destination.WriteChar(character);
            }
        }

        public void CopyMultiples(int numberOfCharacters)
        {
            var characters = _source.ReadChars(numberOfCharacters);

            if (characters.Length >= 1 && !characters[0].Equals(newLine))
            {
                characters = characters.Where(character => character != newLine).ToArray();
                _destination.WriteChars(characters);
            }
        }
    }
}