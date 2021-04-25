using System;
using System.Linq;
using System.Collections.Generic;
namespace ORRAS.Domain.Entities.Enums
{
    public class PersonTitle
    {
        private readonly string _title;
        public static PersonTitle Mr { get; } = new PersonTitle(0, "Mr");
        public static PersonTitle Mrs { get; } = new PersonTitle(1, "Mrs");
        public static PersonTitle Ms { get; } = new PersonTitle(2, "Ms");
        public static PersonTitle Miss { get; } = new PersonTitle(3, "Miss");
        public static PersonTitle Dr { get; } = new PersonTitle(4, "Dr");
        public static PersonTitle Professor { get; } = new PersonTitle(5, "Prof.");


        public string Title { get; private set; }
        public int Value { get; private set; }

        private PersonTitle(int value, string title)
        {
            Value = value;
            Title = title;
        }

        private PersonTitle(){}

        public static IEnumerable<PersonTitle> List()
        {
            return new[] { Mr, Mrs, Ms, Miss, Dr, Professor };
        }
        public static PersonTitle FromString(string personTitleString)
        {
            return List().FirstOrDefault(r => String.Equals(r.Title, personTitleString, StringComparison.OrdinalIgnoreCase));
        }

        public static PersonTitle FromValue(int value)
        {
            return List().FirstOrDefault(r => r.Value == value);
        }

    }
}