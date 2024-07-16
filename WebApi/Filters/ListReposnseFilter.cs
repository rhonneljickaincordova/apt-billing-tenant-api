using Application.DTO;
using Domain.Base;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters;

public class ListResponseFilter <TEntity>: ActionFilterAttribute where TEntity: class, IBaseEntity
{
    public string queryPage { get; set; } = "page";
    public string queryLimit { get; set; } = "limit";

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        // Modify the response result here
        var result = context.Result as ObjectResult;
        if (result is not null) {
            var value = result.Value as PaginatedResponse<TEntity>;
            if (value is not null) {
                context.HttpContext.Response.Headers.Add("X-Total", value.total.ToString());
            }
            var limit = PaginationValue.limit.ToString();
            var page = PaginationValue.page.ToString();
            if (context.HttpContext.Request.Query.ContainsKey(queryLimit)) {
                limit = context.HttpContext.Request.Query.First(d => d.Key == queryLimit).Value;
            }
            if (context.HttpContext.Request.Query.ContainsKey(queryPage)) {
                page = context.HttpContext.Request.Query.First(d => d.Key == queryPage).Value;
            }
            if(context.HttpContext.Request.Query.ContainsKey(queryPage)){
                context.HttpContext.Response.Headers.Add("X-Page", context.HttpContext.Request.Query.First(d=>d.Key == queryPage).Value);	
            }
				
            var total = float.Parse(value.total.ToString());
            var limitInt = float.Parse(limit);
            var totalPage = float.Ceiling(total / limitInt);
            context.HttpContext.Response.Headers.Add("X-Total-Page", totalPage.ToString());
        }
    }
}