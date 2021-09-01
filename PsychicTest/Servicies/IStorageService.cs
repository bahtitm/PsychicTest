namespace PsychicTest.Servicies
{
    public interface IStorageService
    {
        void SetIntoStorge(string key, object value);

        T GetFromStorge<T>(string key);
    }
}
