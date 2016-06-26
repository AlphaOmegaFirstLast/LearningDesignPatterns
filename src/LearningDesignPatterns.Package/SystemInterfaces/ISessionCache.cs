namespace LearningBeta08.Package.SystemInterfaces
{
    public interface ISessionCache
    {
        string Get (string key);
        void Set (string key, string value);
    }
}