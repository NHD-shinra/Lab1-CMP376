using NguyenHuuDat_2380600440.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. THÊM CÁC D?CH V? VÀO CONTAINER (Ph?i n?m TR??C builder.Build())
builder.Services.AddControllersWithViews();

// ??ng ký Repository dùng Mock Data (Singleton) t?i ?ây
builder.Services.AddSingleton<IProductRepository, MockProductRepository>();

var app = builder.Build();

// 2. C?U HÌNH HTTP REQUEST PIPELINE (Sau khi ?ã Build)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 3. C?U HÌNH ??NH TUY?N (ROUTE) - ??a Product lên làm trang ch? m?c ??nh
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 4. CH?Y ?NG D?NG (Luôn luôn là dòng cu?i cùng c?a file)
app.Run();
