﻿using PingPong.Common.Logic.DataConverters.Stringifies.Abstract;

namespace PingPong.Common.Logic.DataConverters.Stringifies
{
    public class StringStringify : IStringify<string>
    {
        public string Parse(string data)
        {
            return data;
        }

        public string Stringify(string data)
        {
            return data;
        }
    }
}