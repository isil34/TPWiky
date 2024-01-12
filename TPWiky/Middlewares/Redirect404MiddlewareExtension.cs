using System.Runtime.CompilerServices;

namespace TPWiky.Middlewares
{
	public static class Redirect404MiddlewareExtension
	{
		public static IApplicationBuilder UseRedirect404(
			this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<Redirect404Middleware>();
		}
	}
}
