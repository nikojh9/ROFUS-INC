var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//tilf�jer session services og laver indstillinger
builder.Services.AddSession(options =>
{
    // G�r sessionen til en session cookie
    options.Cookie.IsEssential = true; // Cookien er essentiel for applikationen
    options.Cookie.HttpOnly = true;     
    options.Cookie.SameSite = SameSiteMode.Lax; 
    
});

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

// Tilf�jer session handling - S� den ved hvorn�r vores brugere er p�.
app.UseSession();


//middelware til tjek om man er logget ind.
// Globalt middleware til at tjekke om brugeren er logget ind
app.Use(async (context, next) =>
{
    // Tjekker om sessionen indeholder en "UserLoggedIn"-v�rdi
    var isLoggedIn = context.Session.GetString("IsLoggedIn") != null;

    // Hvis ikke logget ind, omdiriger til login-siden
    if (!isLoggedIn && context.Request.Path != "/Login" && !context.Request.Path.StartsWithSegments("/Login"))
    {
        context.Response.Redirect("/Login");
        return;
    }

    // Hvis logget ind, forts�t til n�ste middleware
    await next.Invoke();
});


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
