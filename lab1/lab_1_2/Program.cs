// See https://aka.ms/new-console-template for more information

using lab_1_2;

Console.WriteLine("Hello, World!");

IDataFormat date = new EUDataTime();
var gigaTime = new GigaTimeFormatter(date);
var prog = new ProgrammerTimeFormatter(gigaTime);
var decorPost = new GigaTimeFormatter(prog);


Console.WriteLine(decorPost.FormatDateTime());