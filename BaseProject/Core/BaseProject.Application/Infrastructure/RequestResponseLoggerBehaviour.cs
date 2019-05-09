using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Whoever.Entities.Interfaces;

namespace BaseProject.Application.Infrastructure
{
    public class RequestResponseLoggerBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _logger;
        private readonly ICurrentUser<int> _currentUser;

        public RequestResponseLoggerBehaviour(ILogger<TRequest> logger, ICurrentUser<int> currentUser)
        {
            _logger = logger;
            _currentUser = currentUser;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();

            var name = typeof(TRequest).Name;
            var userName = string.Empty;
            if (_currentUser.IsAuthenticated)
            {
                userName = _currentUser.UserName;
            }
            _logger.LogInformation("GS Response: {Name} {@Response} {@UserName}", name, response, userName);

            return response;
        }
    }
}
