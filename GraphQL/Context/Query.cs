using GraphQL.Models;

namespace GraphQL.Context
{
    public class Query
    {
        [UseProjection]
        public IQueryable<Interview> interviews([Service] MyContext context) => context.Interviews;
    }
}
