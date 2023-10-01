namespace ThumbSnap.Domain.Exceptions
{
    public class InvalidVideoPathException : Exception
    {
        public InvalidVideoPathException(string message = "Unable to open the video with the path persisted")
            : base(message)
        {
        }
    }
}