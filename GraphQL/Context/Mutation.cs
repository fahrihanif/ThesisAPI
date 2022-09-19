using GraphQL.Models;

namespace GraphQL.Context
{
    public class Mutation
    {
        public async Task<Interview> SaveInterview([Service] MyContext context, Interview newInterview)
        {
            context.Interviews.Add(newInterview);
            await context.SaveChangesAsync();
            return newInterview;
        }

        public async Task<Interview> UpdateInterview([Service] MyContext context, Interview updateInterview)
        {
            context.Interviews.Update(updateInterview);
            await context.SaveChangesAsync();
            return updateInterview;
        }

        public async Task<string> DeleteInterview([Service] MyContext context, int id)
        {
            var interviewToDelete = await context.Interviews.FindAsync(id);
            if (interviewToDelete == null)
            {
                return "Invalid Operation";
            }
            context.Interviews.Remove(interviewToDelete);
            await context.SaveChangesAsync();
            return "Record Deleted!";
        }
    }
}
