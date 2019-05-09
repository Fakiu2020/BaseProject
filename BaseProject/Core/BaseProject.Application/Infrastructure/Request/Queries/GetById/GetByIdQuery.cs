namespace BaseProject.Application.Infrastructure.Request.Queries.GetById
{
    public abstract class GetByIdQuery<T>
    {
        public T Id { get; set; }
    }
}
