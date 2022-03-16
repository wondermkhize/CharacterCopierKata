namespace CharacterCopy.CopyKata
{
    public interface ISource
    {
        char ReadChar();
        char[] ReadChars(int count);
    }
}