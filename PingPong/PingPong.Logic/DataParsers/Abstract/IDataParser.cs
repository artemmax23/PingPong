namespace PingPong.Logic.DataParsers.Abstract
{
    public interface IDataParser<TParseTo>
    {
        TParseTo Parse(byte[] data);
    }
}
