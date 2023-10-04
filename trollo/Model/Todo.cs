// Todo.cs

namespace Model
{
    public class Todo
    {
        public Todo(string title)
        {
            Title = title;
        }

        public Todo(string title, User user)
        {
            Title = title;
            this.User = user;
        }

        public long TodoId { get; set; }

        public string? Title { get; set; }
   
        public User? User { get; set; }
    }
}

