namespace HsptMS.Abstraction
{
    public interface IPasswordHasher
    {
        void Hash(string password, Guid salt, Guid peeper);



        
    }
}
