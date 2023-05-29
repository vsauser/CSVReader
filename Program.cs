using System;
using System.Globalization;
using System.IO;
using System.Threading;
using CsvHelper;
using CsvHelper.Configuration;

var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
{
    HasHeaderRecord = false,
    Comment = '#',
    AllowComments = true,
    Delimiter = ",",
};

using var streamReader = File.OpenText("query.csv");
using var csvReader = new CsvReader(streamReader, csvConfig);

Console.WriteLine("Start");

csvReader.Read();

PrintData();

void PrintData()
{
    for (var i = 0; i < 8900; i++)
    {
        csvReader.Read();
        var firstName = csvReader.GetField(6);

        Console.WriteLine($"{firstName}");
    }

}

Console.WriteLine("Stop");