using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Dapper;

// Definizione della classe Computer che rappresenta la tabella del database
class Computer
{
    public int ComputerId { get; set; }
    public string Motherboard { get; set; } = "";
    public int CPUCores { get; set; }
    public bool HasWifi { get; set; }
    public bool HasLTE { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public string VideoCard { get; set; } = "";
}

class Program
{
    static void Main(string[] args)
    {
        // Stringa di connessione al database
        string connectionString = "Server=localhost;Database=testDatabase;Trusted_Connection=true;TrustServerCertificate=true;";

        // Connessione al database
        using (var connection = new SqlConnection(connectionString))
        {
            // Query SQL per inserire dati nella tabella Computer
            string insertQuery = @"
            INSERT INTO testAppSchema.Computer (Motherboard, CPUCores, HasWifi, HasLTE, ReleaseDate, Price, VideoCard)
            VALUES (@Motherboard, @CPUCores, @HasWifi, @HasLTE, @ReleaseDate, @Price, @VideoCard)";

            // Esempio di dati da inserire
            var newComputer = new Computer
            {
                Motherboard = "ASUS ROG",
                CPUCores = 8,
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = new DateTime(2023, 1, 1),
                Price = 1499.99M,
                VideoCard = "NVIDIA RTX 3080"
            };

            // Inserimento dei dati
            connection.Execute(insertQuery, newComputer);

            // Query SQL per selezionare i dati dalla tabella Computer
            string selectQuery = "SELECT * FROM testAppSchema.Computer";

            // Recupero dei dati
            var computers = connection.Query<Computer>(selectQuery);

            // Stampa dei dati su terminale
            foreach (var computer in computers)
            {
                Console.WriteLine($"ID: {computer.ComputerId}, Motherboard: {computer.Motherboard}, CPU Cores: {computer.CPUCores}, Wi-Fi: {computer.HasWifi}, LTE: {computer.HasLTE}, Release Date: {computer.ReleaseDate.ToShortDateString()}, Price: {computer.Price}, Video Card: {computer.VideoCard}");
            }
        }
    }
}