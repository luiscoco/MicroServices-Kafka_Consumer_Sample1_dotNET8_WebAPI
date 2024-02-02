using dotNet8WebAPI_Consume_Kafka_JSON_messages.Config;
using dotNet8WebAPI_Consume_Kafka_JSON_messages.Services; // Ensure this namespace is correct
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register KafkaSettings with the DI container for later use in your application
builder.Services.Configure<KafkaSettings>(builder.Configuration.GetSection("Kafka"));

// Adjusted to register KafkaConsumerService for on-demand message consumption
builder.Services.AddSingleton<KafkaConsumerService>(serviceProvider =>
{
    var kafkaSettings = serviceProvider.GetRequiredService<IOptions<KafkaSettings>>();
    return new KafkaConsumerService(kafkaSettings);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
