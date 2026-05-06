namespace UserManagementAPI.Middleware;

public class AuthenticationMiddleware(RequestDelegate next)
{
    private const string ValidToken = "techhive-secret-token";

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();

        if (string.IsNullOrEmpty(token) || token != ValidToken)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new { error = "Unauthorized. Invalid or missing token." });
            return;
        }

        await next(context);
    }
}
