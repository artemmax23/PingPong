namespace PingPong.Server.Common
{
    public class JSONPerson
    {
        public string _name { get; set; }
        public int _age { get; set; }

        public override string ToString()
        {
            return $"{ _name} is { _age } years old.";
        }
    }
}
