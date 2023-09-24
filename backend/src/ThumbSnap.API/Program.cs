using ThumbSnap.Application.Commands.CreateVideoInformation;
using ThumbSnap.IoC.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateVideoInformationCommand).Assembly));
builder.Services.AddDIServices();
builder.Services.AddFluentValidation();
builder.Services.AddOptionsConfiguration(builder.Configuration);
builder.Services.AddDb(builder.Configuration);
builder.Services.AddJobs(builder.Configuration);
builder.Services.AddAutoMapperConfiguration();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
