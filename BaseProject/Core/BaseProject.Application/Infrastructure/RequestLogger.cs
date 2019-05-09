using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Whoever.Entities.Interfaces;

namespace BaseProject.Application.Infrastructure
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly ICurrentUser<int> _currentUser;

        public RequestLogger(ILogger<TRequest> logger, ICurrentUser<int> currentUser)
        {
            _logger = logger;
            _currentUser = currentUser;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;
            var userName = string.Empty;
            // TODO: Add User Details
            if (_currentUser.IsAuthenticated)
            {
                userName = _currentUser.UserName;
            }
            _logger.LogInformation("BP Request: {Name} {@Request} {@UserName}", name, request, userName);

            return Task.CompletedTask;
        }
    }
}
