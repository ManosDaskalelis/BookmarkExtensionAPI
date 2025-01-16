using BookmarkAPI.Data;
using BookmarkAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookmarkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public BookmarkController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookmark>>> GetBookmarks()
        {
             return await _dataContext.Bookmarks.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Bookmark>> AddBookmark(Bookmark bookmark)
        {
            _dataContext.Bookmarks.Add(bookmark);
            await _dataContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBookmarks), new { id = bookmark.Id }, bookmark);
        }
    }
}
