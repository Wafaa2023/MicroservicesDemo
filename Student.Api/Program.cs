using Student.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Common.Repository.IRepository;
using Common.Repository.Repository;
using Student.Service.IServices;
using Student.Service.Services;
using Common.Service.IServices;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//Sql Dependency Injection
var ConnectionString = builder.Configuration.GetConnectionString("DBConnections");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Service Injected
builder.Services.AddScoped(typeof(IRepository<Student.Domain.Models.Student>), typeof(Repository<Student.Domain.Models.Student, StudentDbContext>));
builder.Services.AddScoped<IStudentService , StudentService>();
builder.Services.AddScoped<IBaseService<Student.Domain.Models.Student>, StudentService>();
builder.Services.AddDbContext<StudentDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnections")));
builder.Services.AddGrpc();
#endregion
var app = builder.Build();
// Configure the HTTP request pipeline.
app.MapGrpcService<GrpcStudentService>();
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();