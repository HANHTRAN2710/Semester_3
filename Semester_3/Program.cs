using Semester_3.Models;
using Semester_3.Sơ_Vít.Ìm_le_mần_sơ_vít;
using Semester_3.Sơ_Vít.In_tơ_phây;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddScoped<DatabaseContext>();
builder.Services.AddScoped<IServiceCRUD<Blog>,BlogCRUD>();

builder.Services.AddScoped<IServiceCRUD<Account>, AccountCRUD>();

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
app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );
app.UseStaticFiles();

app.MapControllers();
app.Run();
