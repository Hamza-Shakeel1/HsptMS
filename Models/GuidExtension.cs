namespace HsptMS.Models
{
    public static class GuidExtension
    {
        
        public static Guid GetGuid() { Guid ID = Guid.NewGuid(); return ID; }
    }
}
