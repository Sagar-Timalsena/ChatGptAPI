using ChatGpt.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var chatGptConfig = builder.Configuration.GetSection("ChatGptConfig").Get<ChatGptConfig>();
builder.Services.AddSingleton(chatGptConfig);

// HttpClient for ChatGptService
builder.Services.AddHttpClient<ChatGptService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
