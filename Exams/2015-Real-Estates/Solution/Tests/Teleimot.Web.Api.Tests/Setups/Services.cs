namespace Teleimot.Web.Api.Tests.Setups
{
    using Teleimot.Services.Data;
    using Teleimot.Services.Data.Contracts;

    public static class Services
    {
        public static ICommentsService CommentsService => new CommentsService(Repositories.CommentsRepository);
    }
}
