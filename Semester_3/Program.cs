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
builder.Services.AddScoped<IServiceCRUD<AdministrativeUnit>, AdministrativeUnitCRUD>();
builder.Services.AddScoped<IServiceCRUD<BlogReview>, BlogReviewCRUD>();
builder.Services.AddScoped<IServiceCRUD<CartDetail>, CartDetailCRUD>();
builder.Services.AddScoped<IServiceCRUD<Role>, RoleCRUD>();
builder.Services.AddScoped<IServiceCRUD<Category>, CategoryCRUD>();
builder.Services.AddScoped<IServiceCRUD<Cart>, CartCRUD>();
builder.Services.AddScoped<IServiceCRUD<ProductImage>, ProductImageCRUD>();
builder.Services.AddScoped<IServiceCRUD<Coupon>, CouponCRUD>();
builder.Services.AddScoped<IServiceCRUD<CouponType>, CouponTypeCRUD>();
builder.Services.AddScoped<IServiceCRUD<OrderDetail>, OrderDetailCRUD>();
builder.Services.AddScoped<IServiceCRUD<OrderStatus>, OrderStatusCRUD>();
builder.Services.AddScoped<IServiceCRUD<ProductReview>, ProductReviewCRUD>();
builder.Services.AddScoped<IServiceCRUD<District>, DistrictCRUD>();
builder.Services.AddScoped<IServiceCRUD<Province>, ProvinceCRUD>();
builder.Services.AddScoped<IServiceCRUD<Product>, ProductCRUD>();
builder.Services.AddScoped<IServiceCRUD<Wishlist>, WishlistCRUD>();
builder.Services.AddScoped<IServiceCRUD<PaymentMethod>, PaymentMethodCRUD>();
builder.Services.AddScoped<IServiceCRUD<Account>, AccountCRUD>();
builder.Services.AddScoped<IServiceCRUD<Order>, OrderCRUD>();
builder.Services.AddScoped<IServiceCRUD<Manufacturer>, ManufacturerCRUD>();
builder.Services.AddScoped<IServiceCRUD<Address>, AddressCRUD>();
builder.Services.AddScoped<IServiceCRUD<Ward>, WardCRUD>();
builder.Services.AddScoped<IServiceCRUD<AccountCoupon>, AccountCouponCRUD>();
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
