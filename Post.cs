[Serializable]
public class Post
{
    // Class för gästbokens innehållande objekt 
    public Post(string name, string text)
    {
        Name = name;
        Text = text;
    }
    public string Name { get; set; }
    public string Text { get; set; }
}

