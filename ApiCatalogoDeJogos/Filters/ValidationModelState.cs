using System.Linq;
using ApiCatalogoDeJogos.Models.ErrorModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiCatalogoDeJogos.Filters
{
    public class ValidationModelState : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var validationErrors = new ValidationErrorsModel(
                    context.ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage));
                context.Result = new BadRequestObjectResult(validationErrors);
            }
            base.OnActionExecuting(context);
        }
    }
}
