using Microsoft.AspNetCore.Authentication;
using Model;

using (var db = new BoardContext())
{
    Console.WriteLine($"Database path: {db.DbPath}.");

    // Create
    Console.WriteLine("Indsæt en nyt todo");
    User test = new User("test");
    Todo testTodo = new Todo("Test todo", test);
    Board testBoard = new Board();
    testBoard.Todos.Add(testTodo);
    db.Boards.Add(testBoard);
    db.SaveChanges();

}