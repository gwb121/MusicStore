namespace MusicStore.Models             ////链接到数据库的总类
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MusicStoreEntity : DbContext
    {
        public MusicStoreEntity()
            : base("name=MusicStoreEntity")         ////////     在webconfig中的链接名称
        {
        }

        public virtual DbSet<Albums> Albums { get; set; }
        public virtual DbSet<Artists> Artists { get; set; }
        public virtual DbSet<Carts> Carts { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
