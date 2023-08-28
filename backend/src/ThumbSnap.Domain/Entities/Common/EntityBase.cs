namespace ThumbSnap.Domain.Entities.Common
{
    public class EntityBase
    {
        public virtual Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset ModifiedAt { get;private set; }
        public DateTimeOffset? DeletedAt { get;private set; }

        protected void SetCreatedDate()
        {
            CreatedAt = DateTimeOffset.Now;
            ModifiedAt = DateTimeOffset.Now;
        }

        public void SetModifiedDate()
        {
            ModifiedAt = DateTimeOffset.Now;
        }

        public void SetDeletedDate()
        {
            DeletedAt = DateTimeOffset.Now;
        }
    }
}
