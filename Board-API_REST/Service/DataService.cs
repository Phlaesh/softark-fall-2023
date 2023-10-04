using Microsoft.EntityFrameworkCore;
using System.Text.Json;

using Model;

namespace Service;

public class DataService
{
    private BoardContext db { get; }

    public DataService(BoardContext db) {
        this.db = db;
    }
    /// <summary>
    /// Seeder noget nyt data i databasen hvis det er nødvendigt.
    /// </summary>
    public void SeedData() {
        
        Board board = db.Boards.FirstOrDefault()!;
        if (board == null) {
            board = new Board();
            User user = new User("TestUser");
            board.Todos.Add(new Todo("Sjov", user));
            db.Boards.Add(board);
        }
        db.SaveChanges();
    }

    // Boards
    public List<Board> GetBoards() {
        return db.Boards.Include(t => t.Todos).ThenInclude(t => t.User).ToList();
    }
    public Board GetBoard(int id)
    {
        return db.Boards.Include(t => t.Todos).ThenInclude(t => t.User).FirstOrDefault(b => b.BoardId == id)!;
    }

    public String CreateBoard()
    {
        Board board = new Board();
        db.Boards.Add(board);
        db.SaveChanges();
        return "Board created, id: " + board.BoardId;
    }

    // Todos
    public List<Todo> GetTodos(int boardId)
    {
        return db.Boards.Include(t => t.Todos).ThenInclude(t => t.User).FirstOrDefault(b => b.BoardId == boardId)!.Todos.ToList();
    }
    public Todo GetTodo(int boardId, int todoid)
    {
        return db.Boards.FirstOrDefault(b => b.BoardId == boardId)!.Todos.FirstOrDefault(t => t.TodoId == todoid)!;
    }
  
    /*
    public string CreateTodo(string title, int boardId)
    {
        Board board = db.Boards.FirstOrDefault(b => b.BoardId == boardId);
        Todo todo = new Todo(title);
        board.Todos.Add(todo);
        db.SaveChanges();
        return "Todo created, id: " + todo.TodoId; 
    }
    */

    public string CreateTodo(string title, User user, int boardId)
    {
        Board board = db.Boards.FirstOrDefault(b => b.BoardId == boardId);
        Todo todo = new Todo(title, user);
        board.Todos.Add(todo);
        db.SaveChanges();
        return "Todo created, id: " + todo.TodoId; 
    }

    // Users
    public User GetUser(int boardId, int todoId)
    {
        return db.Boards.FirstOrDefault(b => b.BoardId == boardId)!.Todos.FirstOrDefault(t => t.TodoId == todoId)!.User!;
    }

}