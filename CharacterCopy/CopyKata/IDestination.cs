namespace CharacterCopy.CopyKata
{
    public interface IDestination
    {
        void WriteChar(char character);
        void WriteChars(char[] characters);
    }
}