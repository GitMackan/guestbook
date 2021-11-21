
class GuestBook
{
    // Lista som innehåller poster i Gästboken
    private List<Post> _posts { get; set; } = new List<Post>();

    // Metod för att lägga till nya poster 
    public void AddPost(Post post)
    {
        // Lägger till post till listan
        _posts.Add(post);
    }

    // Metod för att visa innehållet från gästboken
    public void DisplayPosts()
    {
        if (_posts.Count <= 0)
        {
            Console.WriteLine("Finns inga poster än!");
            return;
        }

        // For-loop som skriver ut samtliga poster från listan (_posts)
        for (int i = 0; i < _posts.Count; i++)
        {
            Console.WriteLine($"[{i}] {_posts[i].Name} - {_posts[i].Text}");
        }
    }

    // Metod för att ta bort en post från gästboken
    public void DeletePost(int id)
    {
        // Ta bort post från listan (_posts)
            _posts.RemoveAt(id);
    }
}