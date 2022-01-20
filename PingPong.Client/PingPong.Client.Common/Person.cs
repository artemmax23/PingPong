﻿namespace PingPong.Client.Common
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{ Name} is { Age } years old.";
        }
    }
}
