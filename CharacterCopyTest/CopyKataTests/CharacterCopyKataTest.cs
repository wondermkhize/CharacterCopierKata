using System;
using CharacterCopy.CopyKata;
using NSubstitute;
using NUnit.Framework;

namespace CharacterCopyTest.CopyKataTests
{
    [TestFixture]
    public class CharacterCopyKataTest
    {
        private ISource _source;
        private IDestination _destination;
        private Copier _copier;

        [SetUp]
        public void SetUp()
        {
            _source = Substitute.For<ISource>();
            _destination = Substitute.For<IDestination>();
            _copier = new Copier(_source, _destination);
        }

        [Test]
        public void GIVEN_CopyMethodIsCalled_WHEN_CopyingCharacter_SHOULD_CallReadChar()
        {
            //------------Arrange----------------

            //-------------Act-------------------
            _copier.Copy();

            //------------Assert-----------------
            _source.Received(1).ReadChar();
        }

        [Test]
        public void GIVEN_CopyMethodIsCalled_WHEN_CopyingCharacter_SHOULD_CallWriteChar()
        {
            //------------Arrange----------------

            //-------------Act-------------------
            _copier.Copy();

            //------------Assert-----------------
            _destination.Received(1).WriteChar(Arg.Any<char>());
        }

        [Test]
        public void GIVEN_ReadCharMethodCharacter_WHEN_CopyingCharacter_SHOULD_WriteTheSameCharacter()
        {
            //------------Arrange----------------
            var character = 'A';
            _source.ReadChar().Returns(character);

            //-------------Act-------------------
            _copier.Copy();

            //------------Assert-----------------
            _destination.Received(1).WriteChar(character);
        }

        [Test]
        public void GIVEN_ReadCharMethodReturnsNewline_WHEN_CopyingCharacter_SHOULD_NotCallWriteCharMethod()
        {
            //------------Arrange----------------
            var character = '\n';
            _source.ReadChar().Returns(character);

            //-------------Act-------------------
            _copier.Copy();

            //------------Assert-----------------
            _destination.Received(0).WriteChar(character);
        }

        [Test]
        public void GIVEN_CopyMultiplesMethodIsCalled_WHEN_CopyingArrayOfCharacters_SHOULD_CallReadChars()
        {
            //------------Arrange----------------
            var numberOfCharacters = 4;

            //-------------Act-------------------
            _copier.CopyMultiples(numberOfCharacters);

            //------------Assert-----------------
            _source.Received(1).ReadChars(numberOfCharacters);
        }

        [Test]
        public void GIVEN_ReadCharsMethodReturnsEmptyArray_WHEN_CopyingArrayOfCharacters_SHOULD_NotCallWriteChars()
        {
            //------------Arrange----------------
            var characters = new char[] {};

            //-------------Act-------------------
            _source.ReadChars(Arg.Any<int>()).Returns(characters);
            _copier.CopyMultiples(Arg.Any<int>());

            //------------Assert-----------------
            _destination.Received(0).WriteChars(Arg.Any<char[]>());
        }

        [Test]
        public void GIVEN_ReadCharsMethod_WHEN_CopyingMultipleCharacters_SHOULD_WriteTheCharacters()
        {
            //------------Arrange----------------
            var numberOfCharacters = 4;
            var characters = new char[] {'a', 'b', 'c', '\n'};

            //-------------Act-------------------
            _source.ReadChars(numberOfCharacters).Returns(characters);
            _copier.CopyMultiples(numberOfCharacters);

            //------------Assert-----------------
            _destination.Received(1).WriteChars(Arg.Any<char[]>());
        }

        [Test]
        public void GIVEN_ReadCharsMethodReturnsNewline_WHEN_CopyingMultipleCharacters_SHOULD_NotCallWriteCharsMethod()
        {
            //------------Arrange----------------
            var numberOfCharacters = 1;
            var characters = new char[] {'\n'};

            //-------------Act-------------------
            _source.ReadChars(numberOfCharacters).Returns(characters);
            _copier.CopyMultiples(numberOfCharacters);

            //------------Assert-----------------
            _destination.Received(0).WriteChars(Arg.Any<char[]>());
        }
    }
}