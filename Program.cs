// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace GuestBookApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skriv ut menu 
            Console.WriteLine("------------ Marcus Gästbok ------------" + Environment.NewLine);
            Console.WriteLine("1. Skriv ut gästboken");
            Console.WriteLine("2. Lägg till ett inlägg");
            Console.WriteLine("3. Ta bort ett inlägg");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("X. Avsluta program");

            // Läs in input från användaren och lagra i en variabel
            var userInput = Console.ReadLine();
            var guestBook = new GuestBook();

            // While-loop
            while (true)
            {
                // Switch-sats som kör kod beroende på användarens input
                switch (userInput)
                {
                    // Om användaren skriver i 1
                    case "1":
                        // Skriv ut alla inlägg som finns. Om det är tomt, skriv ut ett meddelande till användare
                        Console.Clear();
                        guestBook.DisplayPosts();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Namn:");
                        var name = "";
                        // Kontrollera att användare fyller i namn
                        while (name.Length < 1)
                        {
                            // Läs in input från användare
                            name = Console.ReadLine();
                            // Om namn är tomt
                            if (String.IsNullOrEmpty(name))
                                Console.WriteLine("Du måste ange namn!");
                            else
                                break;
                        }
                        Console.Clear();
                        Console.WriteLine("Text:");
                        var text = "";
                        // Kontrollera att användare fyller i text
                        while (text.Length < 1)
                        {
                            // Läs in input från användare
                            text = Console.ReadLine();
                            // Om text är tomt
                            if (String.IsNullOrEmpty(text))
                                Console.WriteLine("Du måste ange text!");
                            else
                                break;
                        }
                        var newPost = new Post(name, text);
                        // Lägg till post till lista
                        guestBook.AddPost(newPost);
                        var options = new JsonSerializerOptions { WriteIndented = true };
                        string fileName = "Posts.json";
                        string jsonString = JsonSerializer.Serialize(newPost, options);
                        File.WriteAllText(fileName, jsonString);


                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Vilken post vill du ta bort?");
                        // Gör om input från sträng till integer och lagra i variabel
                        var id = int.Parse(Console.ReadLine());
                        // Ta bort från listan
                        guestBook.DeletePost(id);
                        break;
                    case "X":
                        return;
                    case "x":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Välj ett korrekt alternativ");
                        break;
                }

                // Skriver ut menyn för fortsättning
                Console.WriteLine("----------------------------");
                Console.WriteLine("Vad vill du göra härnäst?");
                Console.WriteLine("1. Skriv ut gästboken");
                Console.WriteLine("2. Lägg till ett inlägg");
                Console.WriteLine("3. Ta bort ett inlägg");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("X. Avsluta program");
                userInput = Console.ReadLine();
            }
        }
    }
}
