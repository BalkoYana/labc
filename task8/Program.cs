using ConsoleApp11;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

using (var db = new AppDbcontext())
{
    var flatRepo = new FlatRepository(db);
    //вибрати всіх у кого вартість квартири
    Console.WriteLine("Enter price");
    int price = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"Ті, у кого  кого вартість квартири {price}:");
    var flatA = await flatRepo.A(price);
    foreach (Flat flat in flatA)
    {
        Console.WriteLine($" площа {flat.Square}, {flat.Id}");
    };
    //вибрати ті квартири де нема інформації про власника

    var flatB = await flatRepo.B();
    Console.WriteLine($"ті квартири де нема інформації про власника :");
    foreach (Flat flat in flatB)
    {
        Console.WriteLine($"площа {flat.Square},{flat.Id}");
    };
    //вибрати квартири які знаходяться на  поверсі і ціна більша 
    Console.WriteLine("Enter price");
    int price1 = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter floor");
    int floor = int.Parse(Console.ReadLine());
    Console.WriteLine($"вибрати квартири які знаходяться на {floor} поверсі і ціна більша за {price1} :");
    var flatC = await flatRepo.C(price1, floor);
    foreach (Flat flat in flatC)
    {
        Console.WriteLine($" ціна {flat.Price}, поверх {flat.Floor}");
    };
    //вивести всі ціни
    var flatD =await flatRepo.D();
    Console.WriteLine($"всі ціни");
    foreach (int flat in flatD)
    {
        Console.WriteLine($"{flat}");
    };
    //порахувати кількість квартир з однаковою вартістю
    var flatE = await flatRepo.E();
    Console.WriteLine($"кількість квартир з однаковою вартістю ціна:");
    foreach (Count flat in flatE)
    {
        Console.WriteLine($"ціна {flat.Price},кількість {flat.Count1}");
    };
    //кількість квартир з однаковою ціною в одному районі ,яка перевищує 3 
    Console.WriteLine("Enter number");
    int number = int.Parse(Console.ReadLine());
    Console.WriteLine($"кількість квартир з однаковою ціною в одному районі ,яка перевищує {number}:");
    var flatF = await flatRepo.F(number);
    foreach (Count flat in flatF)
    {
        Console.WriteLine($"ціна {flat.Price},кількість{flat.Count1}");
    };
    //посортувати у порядку зростання ціни на квартиру
    var flatG = await flatRepo.G();
    Console.WriteLine($"посортувати у порядку зростання ціни на квартиру");
    foreach (Count flat in flatG)
    {
        Console.WriteLine($"{flat.Price}");
    };
    //всі квартири ,у яких ціна дорівнює  змінити на 

    Console.WriteLine("Enter from");
    int from = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter to");
    int to = int.Parse(Console.ReadLine());
    Console.WriteLine($"всі квартири ,у яких ціна дорівнює {from}  змінити на {to}");
    var flatH =await flatRepo.H(to, from);
    Console.WriteLine(flatH);
}
