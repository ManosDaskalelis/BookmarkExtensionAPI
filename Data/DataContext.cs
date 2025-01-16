using BookmarkAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookmarkAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Bookmark> Bookmarks { get; set; }

    }
}
