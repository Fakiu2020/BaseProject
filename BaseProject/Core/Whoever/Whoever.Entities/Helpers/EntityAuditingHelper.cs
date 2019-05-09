using System;
using Whoever.Common.Extensions;
using Whoever.Common.Timing;
using Whoever.Entities.Interfaces;

namespace Whoever.Entities.Helpers
{
    public static class EntityAuditingHelper
    {
        public static void SetCreationAuditProperties<T>(
            object entityAsObj,
            T? userId)
            where T : struct
        {
            var entityWithCreatedDate = entityAsObj as IHasCreationTime;
            if (entityWithCreatedDate == null)
            {
                //Object does not implement ICreatedDate
                return;
            }

            if (entityWithCreatedDate.CreationTime == default(DateTime))
            {
                entityWithCreatedDate.CreationTime = Clock.Now;
            }

            if (!(entityAsObj is ICreationAudited<T>))
            {
                //Object does not implement ICreatedBy
                return;
            }

            if (userId == null)
            {
                //Unknown user
                return;
            }

            var entity = entityAsObj as ICreationAudited<T>;
            if (entity.CreatorUserId != null)
            {
                //CreatorUserId is already set
                return;
            }

            //Finally, set CreatorUserId!
            entity.CreatorUserId = userId;
        }

        public static void SetModificationAuditProperties<T>(
            object entityAsObj,
            T? userId)
            where T : struct
        {
            if (entityAsObj is IHasModificationTime)
            {
                entityAsObj.As<IHasModificationTime>().LastModificationTime = Clock.Now;
            }

            if (!(entityAsObj is IModificationAudited<T>))
            {
                //Entity does not implement IModificationAudited
                return;
            }

            var entity = entityAsObj.As<IModificationAudited<T>>();

            if (userId == null)
            {
                //Unknown user
                entity.LastModifierUserId = default(T);
                return;
            }

            //Finally, set LastModifierUserId!
            entity.LastModifierUserId = userId;
        }

        public static void SetDeletionAuditProperties<T>(
            object entityAsObj,
            T? userId)
            where T : struct
        {
            if (entityAsObj is IHasDeletionTime)
            {
                var entity = entityAsObj.As<IHasDeletionTime>();

                if (entity.DeletionTime == null)
                {
                    entity.DeletionTime = Clock.Now;
                }
            }

            if (entityAsObj is IDeletionAudited<T>)
            {
                var entity = entityAsObj.As<IDeletionAudited<T>>();

                if (entity.DeleterUserId != null)
                {
                    return;
                }

                if (userId == null)
                {
                    entity.DeleterUserId = default(T);
                    return;
                }

                entity.DeleterUserId = userId;
            }
        }
    }
}
