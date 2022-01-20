namespace PingPong.Server.Common
{
    public class Person
    {
        private readonly string _name;
        private readonly int _age;

        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public override string ToString()
        {
            return $"{ _name} is { _age } years old.";
        }
    }
}
