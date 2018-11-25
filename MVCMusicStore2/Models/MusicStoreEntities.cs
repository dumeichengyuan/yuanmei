using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCMusicStore2.Models
{
    //这个类将反映 Entity Framework 数据库的上下文
    //用来处理创建，读取，更新和删除的操作
    public class MusicStoreEntities:DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
    }
}