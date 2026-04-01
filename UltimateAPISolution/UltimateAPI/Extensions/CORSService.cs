namespace UltimateAPI.Extensions
{
    public static class CORSService
    {
        public static IServiceCollection AddCORSConfiguration(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder
                .AllowAnyOrigin()//we can use the WithOrigins("https://example.com") which will allow requests only from that concrete source
                .AllowAnyMethod()// WithMethods("POST", "GET")
                .AllowAnyHeader());//WithHeaders("accept", "content-type") method to allow only specific headers

            } );
        
    }
}
