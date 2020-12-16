using System;
using NUnit.Framework;

using System.Text.Json;
using Jones.Dto;

namespace Jones.UnitTest.Dto
{
    public class IdDtoTest
    {
        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true,
        };
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIdDto()
        {
            var json = JsonSerializer.Serialize(new IdDto<int>(123), _options);
            Console.WriteLine(json);
            var idDto = JsonSerializer.Deserialize<IdDto>(json, _options);
            Console.WriteLine(idDto?.Id);
        }
    }
}