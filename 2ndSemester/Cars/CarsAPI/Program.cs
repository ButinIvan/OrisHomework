using CarsAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Подключение к PostgreSQL через строку подключения из appsettings.json
builder.Services.AddDbContext<CarContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CarContext>();
    db.Database.Migrate();
    
    if (!db.Cars.Any())
    {
        var cars = new List<Car>
        {
            new Car { Brand = "ВАЗ", Name = "ВАЗ 2107", Price = "5K", Rate = "$5/h", Recommend = "78%", Img = "https://auto.vercity.ru/img/magazine/old/2008.12/1199/VAZ%202107%20(1971-2012).jpg", Description = "Классический советский седан с простым дизайном и надежной конструкцией.", Specs = "1.6L R4, 75 HP, 5-Speed Manual, RWD", Owner = "Иван Петров", Contact = "111-222-3333" },  
            new Car { Brand = "ВАЗ", Name = "ВАЗ 2114", Price = "7K", Rate = "$7/h", Recommend = "82%", Img = "https://s.auto.drom.ru/i24207/c/photos/fullsize/vaz/2114/vaz_2114_695038.jpg", Description = "Популярный хэтчбек с улучшенной аэродинамикой и практичным салоном.", Specs = "1.6L R4, 89 HP, 5-Speed Manual, FWD", Owner = "Сергей Иванов", Contact = "444-555-6666" },  
            new Car { Brand = "ВАЗ", Name = "ВАЗ Нива", Price = "10K", Rate = "$10/h", Recommend = "85%", Img = "https://www.zr.ru/d/story/9f/1226949/max_870_580.jpg", Description = "Легендарный внедорожник с постоянным полным приводом и проходимостью.", Specs = "1.7L R4, 83 HP, 5-Speed Manual, 4WD", Owner = "Алексей Смирнов", Contact = "777-888-9999" },  
            new Car { Brand = "ВАЗ", Name = "Lada Granta", Price = "12K", Rate = "$12/h", Recommend = "88%", Img = "https://a.d-cd.net/3oAAAgK1IeA-1920.jpg", Description = "Современный бюджетный седан с улучшенной эргономикой и экономичным двигателем.", Specs = "1.6L R4, 106 HP, 5-Speed Manual, FWD", Owner = "Дмитрий Кузнецов", Contact = "000-111-2222" },  
            
            new Car { Brand = "Haima", Name = "Haima 7", Price = "25K", Rate = "$20/h", Recommend = "83%", Img = "https://cdn.motor1.com/images/mgl/7ZJqA/s1/haima-7x.webp", Description = "Стильный компактный кроссовер с современным дизайном и хорошей комплектацией.", Specs = "1.6L Turbo R4, 194 HP, 6-Speed Automatic, FWD", Owner = "Ли Вэй", Contact = "123-456-7890" },  
            new Car { Brand = "Haima", Name = "Haima 8S", Price = "30K", Rate = "$25/h", Recommend = "85%", Img = "https://carnewschina.com/wp-content/uploads/2020/12/Haima-8S-SUV-China-4.jpg", Description = "Премиальный SUV с мощным двигателем, технологичной начинкой и просторным салоном.", Specs = "1.6L Turbo R4, 195 HP, 6-Speed DCT, FWD", Owner = "Чжан Юн", Contact = "234-567-8901" },  
            new Car { Brand = "Haima", Name = "Haima S7", Price = "22K", Rate = "$18/h", Recommend = "80%", Img = "https://s.auto.drom.ru/i24244/c/photos/fullsize/haima/s7/haima_s7_798386.jpg", Description = "Бюджетный кроссовер с надежной подвеской и экономичным расходом топлива.", Specs = "2.0L R4, 150 HP, 6-Speed Manual, FWD", Owner = "Ван Цзин", Contact = "345-678-9012" },  
            new Car { Brand = "Haima", Name = "Haima M5", Price = "18K", Rate = "$15/h", Recommend = "78%", Img = "https://autoreview.ru/images/Article/1705/Article_170580_860_575.jpg", Description = "Практичный седан для города с комфортной подвеской и доступной ценой.", Specs = "1.5L R4, 113 HP, 5-Speed Manual, FWD", Owner = "Чэнь Ли", Contact = "456-789-0123" }  
        };

        db.Cars.AddRange(cars);
        db.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
