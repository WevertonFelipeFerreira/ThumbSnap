namespace ThumbSnap.Domain.Entities.Common
{
    public class EntityBase
    {
        public virtual Guid Id { get; set; }
        private DateTimeOffset CreatedAt { get; set; }
        private DateTimeOffset ModifiedAt { get; set; }
        private DateTimeOffset? DeletedAt { get; set; }

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
