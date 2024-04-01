using Microsoft.AspNetCore.Mvc;
using Mission11_LGordon.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookstoreContext>(options =>
    {
        options.UseSqlite(builder.Configuration["ConnectionStrings:BookstoreConnection"]);
    }
);

builder.Services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute("pagenumandtype", "{Category}/{pageNum}", new {Controller = "Home", action = "Index"}); 
// does it in an if else order - so if the first line of arranging your url works, it won't even look at the next one
app.MapControllerRoute("Category", "{Category}",new { Controller = "Home", action = "Index", pageNum = 1 });
app.MapControllerRoute("pagination", "{pagenum}", new {Controller = "Home", action = "Index", pageNum = 1}); // what we are passing in, and then the default

app.MapDefaultControllerRoute();

app.Run();