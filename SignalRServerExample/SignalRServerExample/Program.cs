using SignalRServerExample.Business;
using SignalRServerExample.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(option => option
.AddDefaultPolicy(policy => {

    policy.WithOrigins("http://127.0.0.1:5500").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
}
                  
    ));
builder.Services.AddSignalR();
builder.Services.AddTransient<MyBusiness>();
builder.Services.AddControllers();

var app = builder.Build();
app.UseCors();
app.MapHub<MyHub>("/myhub");
app.MapControllers();
app.Run();
