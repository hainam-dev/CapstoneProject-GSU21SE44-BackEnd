﻿namespace Mumbi.Application.Dtos.Vaccine
{
    public class VaccineResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Antigen { get; set; }
        public string ProducingCountry { get; set; }
        public int? Price { get; set; }
    }
}