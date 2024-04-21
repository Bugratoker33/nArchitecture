using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Core.Application.Pipelines.Validation;

public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> //aop devreye sokamak lazım 
    where TRequest : IRequest<TResponse>
{//bir talepde bulununca command önce comadhandelere gitmeden comand handeleri kontrol ediyor  burada bir validasyon ayarlarında bir hata varsa onu fırlatır eğer hata olmasa return Next diye devam ediyor 
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
                                  RequestHandlerDelegate<TResponse> next)
    {
        ValidationContext<object> context = new(request);
        List<ValidationFailure> failures = _validators
                                           .Select(validator => validator.Validate(context))//vlidatorümün validaterini çalıştır
                                           .SelectMany(result => result.Errors)
                                           .Where(failure => failure != null)
                                           .ToList();
        if (failures.Count != 0) throw new ValidationException(failures);
        return next();
    }
}