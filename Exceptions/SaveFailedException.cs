namespace TapChef_Backend.Exceptions
{
    public class SaveFailedException : Exception
    {
        public SaveFailedException(Exception innerException)
            : base("Failed saving changes.", innerException)
        { }
    }
}