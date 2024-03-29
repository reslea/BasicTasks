﻿using System;
using System.IO;

var filePath = "myFile0.txt";
var isExists = File.Exists(filePath);

if (!isExists)
{
    Console.WriteLine("no such file found");
}
using var fs = new FileStream(filePath, FileMode.OpenOrCreate);
using var sr = new StreamReader(fs, detectEncodingFromByteOrderMarks: true);

// если метод помечет async то внутри мы можем использовать await
// await в основном используется для осуществления неблокирующих операций
// неблокирующие = не блокируют поток
// вместо блокировки потока и ожидания, поток освобождается
// позже этот поток получит уведомление о завершении операции
var fileInput = await sr.ReadToEndAsync();
var allLines = fileInput.Split("\r\n");

foreach (var line in allLines)
{
    Console.WriteLine(line);
}